using System;
using VMFramework.GameLogicArchitecture;

namespace TH.Spells
{
    public sealed partial class SpellUnitGeneralSetting : GamePrefabGeneralSetting
    {
        public override Type baseGamePrefabType => typeof(ISpellUnitConfig);

        public override string gameItemName => nameof(SpellUnit);
    }
}