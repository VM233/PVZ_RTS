﻿using UnityEngine.Localization;
using VMFramework.Configuration;

namespace VMFramework.UI
{
    public partial class UIToolkitPanelController : ILocalizedUIPanelController
    {
        protected Locale lastLocale { get; private set; }

        void ILocalizedUIPanelController.OnCurrentLanguageChanged(Locale currentLocale)
        {
            OnCurrentLanguageChanged(currentLocale);
        }

        protected virtual void OnCurrentLanguageChanged(Locale currentLocale)
        {
            if (UISetting.uiPanelGeneralSetting.enableLanguageConfigs == false)
            {
                return;
            }

            if (lastLocale != null)
            {
                var previousLanguageConfig =
                    UISetting.uiPanelGeneralSetting.languageConfigs.GetConfig(currentLocale.Identifier.Code);

                if (previousLanguageConfig != null)
                {
                    rootVisualElement.styleSheets.Remove(previousLanguageConfig.styleSheet);
                }
            }

            lastLocale = currentLocale;

            var currentLanguageConfig =
                UISetting.uiPanelGeneralSetting.languageConfigs.GetConfig(currentLocale.Identifier.Code);

            if (currentLanguageConfig != null)
            {
                rootVisualElement.styleSheets.Add(currentLanguageConfig.styleSheet);
            }
        }
    }
}