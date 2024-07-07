using VMFramework.Core;
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using PVZRTS.Damage;
using Sirenix.OdinInspector;
using UnityEngine;

namespace TH.Spells
{
    public abstract class ProjectileSpellUnit : SpellUnit
    {
        protected IProjectileSpellUnitConfig projectileSpellUnitConfig =>
            (IProjectileSpellUnitConfig)gamePrefab;

        [ShowInInspector]
        protected IChooser<float> scatterAngle { get; private set; }

        [ShowInInspector]
        protected IChooser<int> numbers { get; private set; }

        [ShowInInspector]
        protected IChooser<float> shootingInterval { get; private set; }

        [ShowInInspector]
        protected IChooser<float> delay { get; private set; }

        [ShowInInspector]
        protected IChooser<int> physicalAttack { get; private set; }

        [ShowInInspector]
        protected IChooser<int> magicalAttack { get; private set; }

        protected override void OnFirstCreated()
        {
            base.OnFirstCreated();
            
            scatterAngle = projectileSpellUnitConfig.scatterAngle;
            numbers = projectileSpellUnitConfig.numbers;
            shootingInterval = projectileSpellUnitConfig.shootingInterval;
            delay = projectileSpellUnitConfig.delay;
            physicalAttack = projectileSpellUnitConfig.physicalAttack;
            magicalAttack = projectileSpellUnitConfig.magicalAttack;
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            
            ResetArguments();
        }

        public override void ResetArguments()
        {
            scatterAngle.ResetChooser();
            numbers.ResetChooser();
            shootingInterval.ResetChooser();
            delay.ResetChooser();
            physicalAttack.ResetChooser();
            magicalAttack.ResetChooser();
        }

        public override async UniTask Examine(ISpell spell, SpellCastInfo spellCastInfo)
        {
            float unitDelay = delay.GetValue();

            if (unitDelay > 0)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(unitDelay));
            }

            Vector3 mainDirection;

            if (spellCastInfo.targetType.HasFlag(SpellTargetType.Direction))
            {
                mainDirection = spellCastInfo.mainDirection;
            }
            else if (spellCastInfo.targetType.HasFlag(SpellTargetType.Entities))
            {
                Transform nearestEntityTransform = default;
                float nearestDistance = float.MaxValue;

                var casterPosition = spellCastInfo.caster.casterPosition;
                foreach (var entity in spellCastInfo.entities)
                {
                    var entityTransform = entity.controller.transform;

                    var distance = entityTransform.position.EuclideanDistance(casterPosition);

                    if (distance < nearestDistance)
                    {
                        nearestDistance = distance;
                        nearestEntityTransform = entityTransform;
                    }
                }

                if (nearestEntityTransform == null)
                {
                    return;
                }

                mainDirection = nearestEntityTransform.position - casterPosition;
            }
            else if (spellCastInfo.targetType.HasFlag(SpellTargetType.Position))
            {
                mainDirection = spellCastInfo.mainPosition - spellCastInfo.caster.casterPosition;
            }
            else
            {
                throw new ArgumentException($"{spellCastInfo.targetType} is not supported.");
            }

            int numbers = this.numbers.GetValue();

            List<float> angles;

            if (numbers == 1)
            {
                angles = new() { 0f };
            }
            else
            {
                float minAngle, maxAngle;

                (minAngle, maxAngle) = 0f.GetMinMaxPointFromPivotExtents(scatterAngle.GetValue() / 2);

                angles = minAngle.GetUniformlySpacedPoints(maxAngle, numbers).ToList();
            }

            Vector3 axis;

            switch (projectileSpellUnitConfig.directionRotationType)
            {
                case ProjectileDirectionRotationType.AroundUpAxis:
                    axis = Vector3.up;
                    break;
                case ProjectileDirectionRotationType.AroundPerpendicularAxis:
                    axis = mainDirection.RotateWithinPlane(Vector3.up, 90);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (projectileSpellUnitConfig.shuffleProjectiles && angles.Count > 1)
            {
                angles.Shuffle();
            }

            for (int i = 0; i < numbers; i++)
            {
                Vector3 spawnPosition = projectileSpellUnitConfig.projectileSpawnPosition switch
                {
                    ProjectileSpawnPosition.Caster => spellCastInfo.caster.casterCastingPosition,
                    ProjectileSpawnPosition.Owner => spell.owner.ownerCastingPosition,
                    _ => throw new ArgumentOutOfRangeException()
                };

                var direction = mainDirection.ClockwiseRotate(angles[i], axis);

                CreateProjectile(spell, spellCastInfo, spawnPosition, direction);

                if (i != numbers - 1)
                {
                    float interval = shootingInterval.GetValue();

                    if (interval > 0)
                    {
                        await UniTask.WaitForSeconds(interval);

                        if (spell.IsAborted())
                        {
                            return;
                        }
                    }
                }
            }
        }

        protected abstract void CreateProjectile(ISpell spell, SpellCastInfo spellCastInfo,
            Vector3 spawnPosition, Vector3 direction);

        protected virtual DamagePacket ProcessDamagePacket(DamagePacket damagePacket)
        {
            damagePacket.isMelee = projectileSpellUnitConfig.isMelee;
            damagePacket.physicalDamage += physicalAttack.GetValue();
            damagePacket.magicalDamage += magicalAttack.GetValue();
            return damagePacket;
        }

        public override void Abort(SpellAbortInfo spellAbortInfo)
        {
            
        }
    }
}