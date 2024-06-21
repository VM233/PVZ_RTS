using Sirenix.OdinInspector;
using VMFramework.Configuration;

namespace TH.Spells
{
    public abstract partial class SpellUnitAction : BaseConfig, ISpellUnitAction
    {
        [PropertyOrder(-1000)]
        [ShowInInspector]
        public abstract SpellTargetType supportedTargetType { get; }

        public abstract void Examine(ISpell spell, SpellCastInfo spellCastInfo, 
            SpellOperationToken operationToken);
    }
}