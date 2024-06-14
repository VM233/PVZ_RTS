namespace PVZRTS.Entities
{
    public interface IControllableEntity : IMoveableEntity
    {
        public bool CanControl() => true;
    }
}