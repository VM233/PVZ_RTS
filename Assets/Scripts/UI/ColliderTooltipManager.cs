using System;
using System.Collections.Generic;
using PVZRTS.GameCore;
using VMFramework.Core.Linq;
using VMFramework.GameEvents;
using VMFramework.Procedure;
using VMFramework.UI;

namespace PVZRTS.UI
{
    [ManagerCreationProvider(nameof(GameManagerType.UI))]
    public sealed class ColliderTooltipManager : ManagerBehaviour<ColliderTooltipManager>, IManagerBehaviour
    {
        protected override IEnumerable<InitializationAction> GetInitializationActions()
        {
            return base.GetInitializationActions()
                .Concat(new(InitializationOrder.InitComplete, OnInitComplete, this));
        }

        private static void OnInitComplete(Action onDone)
        {
            ColliderMouseEventManager.AddCallback(MouseEventType.PointerEnter, OnPointerEnter);
            ColliderMouseEventManager.AddCallback(MouseEventType.PointerExit, OnPointerExit);
            
            onDone();
        }

        private static void OnPointerEnter(ColliderMouseEvent e)
        {
            if (e.trigger.owner.TryGetComponent(out ITooltipProviderController tooltipProviderController))
            {
                TooltipManager.Open(tooltipProviderController.provider, null);
            }
        }
        
        private static void OnPointerExit(ColliderMouseEvent e)
        {
            if (e.trigger.owner.TryGetComponent(out ITooltipProviderController tooltipProviderController))
            {
                TooltipManager.Close(tooltipProviderController.provider);
            }
        }
    }
}