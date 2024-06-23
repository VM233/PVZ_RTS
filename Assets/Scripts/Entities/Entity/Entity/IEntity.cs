using UnityEngine;
using VMFramework.GameLogicArchitecture;
using VMFramework.Network;

namespace PVZRTS.Entities
{
    public interface IEntity : IVisualGameItem, IUUIDOwner
    {
        public IEntityController controller { get; }
        
        public GameObject prefab { get; }
        
        public void Init(IEntityController entityController);
    }
}