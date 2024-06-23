using UnityEngine;
using VMFramework.Core;

namespace TH.Spells
{
    public interface ISpellOwnerController : IController
    {
        public Transform ownerCastingTransform { get; }
    }
}