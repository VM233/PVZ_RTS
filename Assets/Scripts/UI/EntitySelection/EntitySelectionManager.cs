using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using PVZRTS.Entities;
using PVZRTS.GameCore;
using Sirenix.OdinInspector;
using VMFramework.Procedure;

namespace PVZRTS.UI
{
    [ManagerCreationProvider(nameof(GameManagerType.UI))]
    public sealed class EntitySelectionManager : ManagerBehaviour<EntitySelectionManager>
    {
        [ShowInInspector]
        public static EntitySelection selection { get; private set; }

        public static event Action<EntitySelection> OnSelectionChanged; 

        private static readonly List<IEntity> selectedEntities = new();
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Select(IEntity entity)
        {
            selection = new EntitySelection(entity);
            OnSelectionChanged?.Invoke(selection);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Select(IEnumerable<IEntity> entities)
        {
            selectedEntities.Clear();
            selectedEntities.AddRange(entities);
            selection = new EntitySelection(selectedEntities);
            OnSelectionChanged?.Invoke(selection);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Deselect()
        {
            selection = new((IEntity)null);
            OnSelectionChanged?.Invoke(selection);
        }
    }
}