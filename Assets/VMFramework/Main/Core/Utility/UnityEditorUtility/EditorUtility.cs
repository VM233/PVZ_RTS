#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEditor;
using VMFramework.Core.Linq;

namespace VMFramework.Core.Editor
{
    public static class EditorUtility
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MonoScript MonoScriptFromScriptName(string scriptName)
        {
            foreach (var monoScript in scriptName.FindAssetsOfName<MonoScript>(null))
            {
                return monoScript;
            }

            return null;
            // return AssetDatabase.FindAssets($"{scriptName} t:MonoScript")
            //     .Select(AssetDatabase.GUIDToAssetPath)
            //     .Select(AssetDatabase.LoadAssetAtPath<MonoScript>)
            //     .FirstOrDefault();
        }

        public static bool OpenScriptOfType(this Type type)
        {
            if (type == null)
            {
                return false;
            }
            
            var typeName = type.Name;
            if (type.IsGenericType)
            {
                type = type.GetGenericTypeDefinition();
                typeName = typeName[..typeName.IndexOf('`')];
            }
            
            var mono = MonoScriptFromScriptName(typeName);
            if (mono != null)
            {
                AssetDatabase.OpenAsset(mono);
                return true;
            }

            Debug.LogWarning($"Failed to open script of type {type.Name}, " +
                             $"because no script file named {typeName}.cs exists in the project.");
            return false;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void OpenScriptOfObject(this object obj)
        {
            if (obj == null)
            {
                Debug.LogWarning($"{nameof(obj)} is null! Can't open script.");
                return;
            }
            
            obj.GetType().OpenScriptOfType();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void OpenScriptOfObjects<TObject>(this IEnumerable<TObject> objects)
        {
            if (objects == null)
            {
                Debug.LogWarning($"{nameof(objects)} is null! Can't open script.");
                return;
            }
            
            objects.Examine(obj => obj.OpenScriptOfObject());
        }
    }
}

#endif