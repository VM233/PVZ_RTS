using System;
using VMFramework.GameLogicArchitecture;

namespace TH.Spells
{
    public sealed partial class SpellGeneralSetting : GamePrefabGeneralSetting
    {
        #region Meta Data

        public override Type baseGamePrefabType => typeof(SpellConfig);

        public override string gameItemName => nameof(Spell);

        #endregion
    }
}
