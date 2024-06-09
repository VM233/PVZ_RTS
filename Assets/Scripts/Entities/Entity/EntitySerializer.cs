using FishNet.Serializing;
using VMFramework.GameLogicArchitecture;

namespace PVZRTS.Entities
{
    public static class EntitySerializer
    {
        public static void WriteEntity(this Writer writer, IEntity entity)
        {
            entity.WriteGameItem(writer);
        }

        public static IEntity ReadEntity(this Reader reader)
        {
            return reader.ReadGameItem<IEntity>();
        }
    }
}