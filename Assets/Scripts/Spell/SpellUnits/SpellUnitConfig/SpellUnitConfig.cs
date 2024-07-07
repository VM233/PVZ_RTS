using Sirenix.OdinInspector;
using VMFramework.GameLogicArchitecture;

namespace TH.Spells
{
    public abstract class SpellUnitConfig : GameTypedGamePrefab, ISpellUnitConfig
    {
        protected override string idSuffix => "spell_unit";

        [TabGroup(TAB_GROUP_NAME, BASIC_CATEGORY)]
        [PropertyOrder(-1000)]
        [ShowInInspector]
        public abstract SpellTargetType supportedTargetType { get; }
    }
}