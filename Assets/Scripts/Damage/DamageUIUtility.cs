using System.Runtime.CompilerServices;
using PVZRTS.GameCore;
using UnityEngine;
using VMFramework.Core;
using VMFramework.UI;

namespace PVZRTS.Damage
{
    public static class DamageUIUtility
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PopupHealthChange(int healthChange, Vector3 position)
        {
            var value = healthChange.Abs();

            Color textColor = healthChange > 0
                ? GameSetting.damageGeneralSetting.healthRegainColor
                : GameSetting.damageGeneralSetting.healthReductionColor;
            
            PopupManager.PopupText(GameSetting.damageGeneralSetting.healthChangePopupUIPanelID,
                position, healthChange, textColor);
        }
    }
}