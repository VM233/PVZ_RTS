using System.Collections.Generic;
using PVZRTS.Entities;
using UnityEngine;

namespace TH.Spells
{
    public struct SpellCastInfo
    {
        public ISpellCaster caster { get; init; }
        public SpellTargetType targetType { get; init; }
        public IEnumerable<IEntity> entities { get; init; }
        public Vector3 mainDirection { get; init; }
        public Vector3 mainPosition { get; init; }
    }
}