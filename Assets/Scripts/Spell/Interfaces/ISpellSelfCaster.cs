namespace TH.Spells
{
    /// <summary>
    /// The interface indicates that the spell caster and owner are the same.
    /// </summary>
    public interface ISpellSelfCaster : ISpellCaster, ISpellOwner
    {
        
    }
}