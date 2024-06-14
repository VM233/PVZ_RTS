using UnityEngine;
using VMFramework.GameLogicArchitecture;

namespace PVZRTS.Entities
{
    public interface IEntityConfig : IDescribedGamePrefab
    {
        public int prewarmCount { get; }
        
        public GameObject prefab { get; }
    }
}