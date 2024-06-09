using System;
using VMFramework.GameLogicArchitecture;

namespace PVZRTS.Entities
{
    public partial class EntityConfig : DescribedGamePrefab, IEntityConfig
    {
        public override Type gameItemType => typeof(Entity);
    }
}