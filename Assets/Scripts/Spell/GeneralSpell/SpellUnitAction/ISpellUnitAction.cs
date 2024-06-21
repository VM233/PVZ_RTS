using VMFramework.Configuration;

namespace TH.Spells
{
    public interface ISpellUnitAction : IConfig
    {
        public SpellTargetType supportedTargetType { get; }

        public void Examine(ISpell spell, SpellCastInfo spellCastInfo, 
            SpellOperationToken operationToken);
    }
}