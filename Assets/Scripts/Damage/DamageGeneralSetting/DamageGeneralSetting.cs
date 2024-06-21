using Sirenix.OdinInspector;
using UnityEngine;
using VMFramework.GameLogicArchitecture;
using VMFramework.OdinExtensions;

namespace PVZRTS.Damage
{
    public sealed partial class DamageGeneralSetting : GeneralSetting
    {
        private const string DAMAGE_UI_CATEGORY = "Damage UI";
        
        [TabGroup(TAB_GROUP_NAME, DAMAGE_UI_CATEGORY)]
        [UIPresetID]
        [IsNotNullOrEmpty]
        public string healthChangePopupUIPanelID;
        
        [TabGroup(TAB_GROUP_NAME, DAMAGE_UI_CATEGORY)]
        public Color healthReductionColor;
        
        [TabGroup(TAB_GROUP_NAME, DAMAGE_UI_CATEGORY)]
        public Color healthRegainColor;
    }
}
