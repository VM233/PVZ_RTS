#if UNITY_EDITOR
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using VMFramework.Configuration;
using VMFramework.GameLogicArchitecture;
using VMFramework.UI;

namespace VMFramework.OdinExtensions
{
    public sealed class TooltipPriorityPresetIDAttributeDrawer
        : GeneralValueDropdownAttributeDrawer<TooltipPriorityPresetIDAttribute>
    {
        protected override IEnumerable<ValueDropdownItem> GetValues()
        {
            return UISetting.tooltipGeneralSetting.tooltipPriorityPresets.GetNameList();
        }
    }
}
#endif