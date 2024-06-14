using UnityEngine;
using VMFramework.GameLogicArchitecture;
using VMFramework.Network;

namespace PVZRTS.Entities
{
    public interface IEntity : IVisualGameItem, IUUIDOwner
    {
        public EntityController controller { get; }
        
        public GameObject prefab { get; }
        
        public void Init(EntityController entityController);
    }
}