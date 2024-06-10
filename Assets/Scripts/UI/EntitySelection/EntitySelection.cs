using System.Collections.Generic;
using PVZRTS.Entities;

namespace PVZRTS.UI
{
    public readonly struct EntitySelection
    {
        public readonly EntitySelectionType type;
        public readonly IEntity entity;
        public readonly IReadOnlyList<IEntity> entities;

        public EntitySelection(IEntity entity)
        {
            if (entity == null)
            {
                type = EntitySelectionType.None;
                this.entity = null;
                entities = null;
            }
            else
            {
                type = EntitySelectionType.Single;
                this.entity = entity;
                entities = null;
            }
        }
        
        public EntitySelection(IReadOnlyList<IEntity> entities)
        {
            if (entities == null || entities.Count == 0)
            {
                type = EntitySelectionType.None;
                entity = null;
                this.entities = null;
            }
            else if (entities.Count == 1)
            {
                type = EntitySelectionType.Single;
                entity = entities[0];
                this.entities = null;
            }
            else
            {
                type = EntitySelectionType.Multiple;
                this.entities = entities;
                entity = null;
            }
        }
    }
}