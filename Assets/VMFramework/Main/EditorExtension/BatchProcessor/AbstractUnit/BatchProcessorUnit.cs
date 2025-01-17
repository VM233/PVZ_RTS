﻿#if UNITY_EDITOR
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace VMFramework.Editor.BatchProcessor
{
    [HideDuplicateReferenceBox]
    [HideReferenceObjectPicker]
    public abstract class BatchProcessorUnit
    {
        protected BatchProcessorContainer container { get; private set; }

        public void Init(BatchProcessorContainer container)
        {
            this.container = container;
        }

        public abstract bool IsValid(IList<object> selectedObjects);

        public virtual void OnSelectedObjectsChanged(IList<object> selectedObjects)
        {
            
        }
    }
}

#endif