using UnityEngine;
using VMFramework.GameLogicArchitecture;

namespace TH.Spells
{
    public interface ISpellConfig : IDescribedGamePrefab
    {
        public Sprite icon { get; }
        
        public float maxCooldown { get; }
    }
}