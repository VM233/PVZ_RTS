using PVZRTS.Damage;
using UnityEngine;
using VMFramework.Network;

namespace TH.Spells
{
    public interface ISpellCaster : IDamageSource, IUUIDOwner
    {
        /// <summary>
        /// The position where the spell caster is located.
        /// </summary>
        public Vector3 casterPosition { get; }

        /// <summary>
        /// The position where the spell caster is casting the spell from.
        /// </summary>
        public Vector3 casterCastingPosition { get; }
    }
}
