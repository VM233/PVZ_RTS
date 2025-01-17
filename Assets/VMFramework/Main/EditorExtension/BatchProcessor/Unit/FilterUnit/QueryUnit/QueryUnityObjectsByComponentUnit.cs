﻿#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VMFramework.OdinExtensions;

namespace VMFramework.Editor.BatchProcessor
{
    public sealed class QueryUnityObjectsByComponentUnit : SingleButtonBatchProcessorUnit
    {
        protected override string processButtonName => "Query By Component";

        [SerializeField]
        [TypeValueDropdown(typeof(Component), IncludingSelf = false, IncludingAbstract = true,
            IncludingGeneric = false, IncludingInterfaces = false)]
        private Type componentType;

        public override bool IsValid(IList<object> selectedObjects)
        {
            return selectedObjects.Any(obj => obj is GameObject);
        }

        protected override IEnumerable<object> OnProcess(IReadOnlyList<object> selectedObjects)
        {
            return selectedObjects.Where(o =>
                o is GameObject gameObject &&
                gameObject.GetComponent(componentType) != null);
        }
    }
}
#endif