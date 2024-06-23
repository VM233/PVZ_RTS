using UnityEngine;

namespace TH.Spells
{
    public interface ISpellOwner
    {
        /// <summary>
        /// The position where the spell owner is casting the spell from.
        /// </summary>
        public Vector3 ownerCastingPosition { get; }
    }
}
