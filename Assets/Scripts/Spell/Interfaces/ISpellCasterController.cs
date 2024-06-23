using UnityEngine;
using VMFramework.Core;

namespace TH.Spells
{
    public interface ISpellCasterController : IController
    {
        public Transform casterCastingTransform { get; }
    }
}