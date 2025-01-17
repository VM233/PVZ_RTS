﻿#if UNITY_EDITOR
using System;
using Sirenix.OdinInspector;

namespace VMFramework.GameLogicArchitecture
{
    public partial class GeneralSetting
    {
        [PropertyOrder(-100000)]
        [OnInspectorInit(nameof(OnInspectorInit))]
        [ShowInInspector]
        private Type generalSettingType => GetType();

        protected override void OnInspectorInit()
        {
            base.OnInspectorInit();
            
            AutoConfigureLocalizedString(new()
            {
                defaultTableName = defaultLocalizationTableName,
                save = true
            });
        }
    }
}
#endif