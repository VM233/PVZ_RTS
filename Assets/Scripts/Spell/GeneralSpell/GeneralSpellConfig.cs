using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using VMFramework.OdinExtensions;

namespace TH.Spells
{
    public sealed partial class GeneralSpellConfig : SpellConfig
    {
        public override Type gameItemType => typeof(GeneralSpell);

        [TabGroup(TAB_GROUP_NAME, SPELL_CATEGORY)]
        [GamePrefabID(typeof(ISpellUnitConfig))]
        [IsNotNullOrEmpty]
        public List<string> spellUnitsID = new();
    }
}
