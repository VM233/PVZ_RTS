﻿using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using VMFramework.Procedure;

namespace VMFramework.GameLogicArchitecture
{
    public static class GlobalSettingCollector
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<IGlobalSetting> Collect()
        {
            foreach (var manager in ManagerBehaviourCollector.Collect())
            {
                if (manager is IGlobalSetting globalSetting)
                {
                    yield return globalSetting;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<IGeneralSetting> GetAllGeneralSettings()
        {
            foreach (var globalSetting in Collect())
            {
                if (globalSetting.globalSettingFile == null)
                {
                    Debug.LogWarning($"GlobalSetting {globalSetting.name} has no GlobalSettingFile assigned.");
                    continue;
                }

                foreach (var generalSetting in globalSetting.globalSettingFile.GetAllGeneralSettings())
                {
                    yield return generalSetting;
                }
            }
        }
    }
}