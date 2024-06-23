using VMFramework.Configuration;
using VMFramework.Core;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using PVZRTS.Damage;
using UnityEngine;
using VMFramework.OdinExtensions;

namespace TH.Spells
{
    public abstract partial class ProjectileUnitAction : SpellUnitAction
    {
        [SerializeField]
        private ProjectileDirectionRotationType directionRotationType;
        
        [PreviewCompositeSettings("°")]
        [Minimum(0)]
        [SerializeField]
        private IVectorChooserConfig<float> scatterAngle = new SingleVectorChooserConfig<float>(30f);

        [SerializeField]
        private bool shuffleProjectiles = false;

        [Minimum(1)]
        [SerializeField]
        private IVectorChooserConfig<int> numbers = new SingleVectorChooserConfig<int>(1);

        [PreviewCompositeSettings("seconds")]
        [Minimum(0)]
        [SerializeField]
        private IVectorChooserConfig<float> shootingInterval = new SingleVectorChooserConfig<float>(0);

        [EnumToggleButtons]
        [SerializeField]
        private ProjectileSpawnPosition projectileSpawnPosition;

        [PreviewCompositeSettings("seconds")]
        [Minimum(0)]
        [SerializeField]
        private IVectorChooserConfig<float> delay = new SingleVectorChooserConfig<float>(0);
        
        [SerializeField]
        private bool isMelee = false;
        
        [SerializeField]
        private IVectorChooserConfig<int> physicalAttack = new SingleVectorChooserConfig<int>(1);

        [SerializeField]
        private IVectorChooserConfig<int> magicalAttack = new SingleVectorChooserConfig<int>(1);

        public override async void Examine(ISpell spell, SpellCastInfo spellCastInfo,
            SpellOperationToken operationToken)
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

                (minAngle, maxAngle) = 
                    0f.GetMinMaxPointFromPivotExtents(scatterAngle.GetValue() / 2);

                angles = minAngle.GetUniformlySpacedPoints(maxAngle, numbers).ToList();
            }

            Vector3 axis;

            switch (directionRotationType)
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

            if (shuffleProjectiles && angles.Count > 1)
            {
                angles.Shuffle();
            }

            for (int i = 0; i < numbers; i++)
            {
                Vector3 spawnPosition = projectileSpawnPosition switch
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

                        if (operationToken.IsAborted())
                        {
                            return;
                        }
                    }
                }
            }

            operationToken.Complete();
        }

        protected abstract void CreateProjectile(ISpell spell, SpellCastInfo spellCastInfo,
            Vector3 spawnPosition, Vector3 direction);

        protected virtual DamagePacket ProcessDamagePacket(DamagePacket damagePacket)
        {
            damagePacket.isMelee = isMelee;
            damagePacket.physicalDamage += physicalAttack.GetValue();
            damagePacket.magicalDamage += magicalAttack.GetValue();
            return damagePacket;
        }
    }

}