using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Utils.Attributes;
using Object = UnityEngine.Object;

namespace Utils.Editor.Drawers
{
    [InitializeOnLoad]
    public static class RequiredFieldHierarchyDrawer
    {
        private static readonly Dictionary<Type, FieldInfo[]> s_CachedRequiredFields = new();
        
        static RequiredFieldHierarchyDrawer()
        {
            EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyWindowItemOnGUI;
        }
        
        private static void OnHierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
        {
            if (EditorUtility.InstanceIDToObject(instanceID) is not GameObject gameObject)
                return;
            
            if ((from component in gameObject.GetComponents<MonoBehaviour>()
                    where component != null
                    let fields = GetCachedRequiredFields(component.GetType())
                    where fields != null && fields.Length != 0
                    where fields.Any(f => IsFieldInvalid(f.GetValue(component)))
                    select component).Any())
            {
                EditorGUI.DrawRect(selectionRect, new(1f, 0.2f, 0.2f, 0.2f));
            }
        }
        
        private static FieldInfo[] GetCachedRequiredFields(Type type)
        {
            if (!s_CachedRequiredFields.TryGetValue(type, out FieldInfo[] fields))
            {
                // Get all fields that are public or have the SerializeField attribute and are marked as required
                fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                    .Where(f => (f.IsPublic || f.GetCustomAttribute<SerializeField>() != null)
                                && f.GetCustomAttribute<RequiredFieldAttribute>() != null)
                    .ToArray();
                s_CachedRequiredFields[type] = fields;
            }
            return fields;
        }
        
        private static bool IsFieldInvalid(object fieldValue)
        {
            return fieldValue switch
            {
                null => true,
                Object obj => obj == null,
                string str => string.IsNullOrEmpty(str),
                _ => false
            };
        }
    }
}
