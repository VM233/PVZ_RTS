using System;
using VMFramework.GameLogicArchitecture;
using Sirenix.OdinInspector;
using UnityEngine;

namespace TH.Spells
{
    public abstract partial class SpellConfig : DescribedGamePrefab, ISpellConfig
    {
        protected const string SPELL_CATEGORY = "Spell";

        protected override string idSuffix => "spell";

        public override Type gameItemType => typeof(Spell);

        [TabGroup(TAB_GROUP_NAME, SPELL_CATEGORY)]
        [PreviewField(50, ObjectFieldAlignment.Center)]
        public Sprite icon;

        [SuffixLabel("seconds"), TabGroup(TAB_GROUP_NAME, SPELL_CATEGORY)]
        [MinValue(0)]
        public float maxCooldown;

        #region Interface Implementation

        Sprite ISpellConfig.icon => icon;

        float ISpellConfig.maxCooldown => maxCooldown;

        #endregion
    }
}
