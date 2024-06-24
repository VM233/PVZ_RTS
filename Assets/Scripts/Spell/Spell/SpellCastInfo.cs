using System;
using System.Collections.Generic;
using PVZRTS.Entities;
using UnityEngine;

namespace TH.Spells
{
    public readonly struct SpellCastInfo
    {
        public readonly ISpellCaster caster;
        public readonly SpellTargetType targetType;
        public readonly IEnumerable<IEntity> entities;
        public readonly Vector3 mainDirection;
        public readonly Vector3 mainPosition;

        public SpellCastInfo(ISpellCaster caster, SpellTargetType targetType, IEnumerable<IEntity> entities,
            Vector3 mainDirection, Vector3 mainPosition)
        {
            this.caster = caster;
            this.targetType = targetType;
            this.entities = entities;
            this.mainDirection = mainDirection;
            this.mainPosition = mainPosition;
        }

        public SpellCastInfo(ISpellCaster caster, IEnumerable<IEntity> entities)
        {
            this.caster = caster;
            this.targetType = SpellTargetType.Entities;
            this.entities = entities;
            this.mainDirection = Vector3.zero;
            this.mainPosition = Vector3.zero;
        }

        public SpellCastInfo(ISpellCaster caster, SpellTargetType targetType, Vector3 mainDirectionOrPosition)
        {
            this.caster = caster;
            this.entities = null;

            if (targetType == SpellTargetType.Direction)
            {
                this.targetType = SpellTargetType.Direction;
                this.mainDirection = mainDirectionOrPosition;
                this.mainPosition = Vector3.zero;
            }
            else if (targetType == SpellTargetType.Position)
            {
                this.targetType = SpellTargetType.Position;
                this.mainDirection = Vector3.zero;
                this.mainPosition = mainDirectionOrPosition;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(targetType));
            }
        }
    }
}