using UnityEditor;
using UnityEngine;
using Utils.Attributes;

namespace Utils.Editor.Drawers
{
    [CustomPropertyDrawer(typeof(RequiredFieldAttribute))]
    public class RequiredFieldDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            
            EditorGUI.BeginChangeCheck();
            
            Rect fieldRect = new(position.x + EditorGUIUtility.labelWidth, position.y, position.width - EditorGUIUtility.labelWidth, position.height);
            Color originalColor = GUI.backgroundColor;
            
            // Draw the field with a red background if it's invalid
            if (IsFieldInvalid(property))
            {
                GUI.backgroundColor = Color.red;
                GUI.Label(fieldRect, new GUIContent("", "This field is required and is either missing or empty."));
            }
            
            EditorGUI.PropertyField(position, property, label);
            
            // Reset the GUI color
            GUI.backgroundColor = originalColor;
            
            if (EditorGUI.EndChangeCheck())
            {
                property.serializedObject.ApplyModifiedProperties();
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }
            
            EditorGUI.EndProperty();
        }
        
        private static bool IsFieldInvalid(SerializedProperty property)
        {
            return property.propertyType switch
            {
                SerializedPropertyType.ObjectReference => property.objectReferenceValue == null,
                SerializedPropertyType.ExposedReference => property.exposedReferenceValue == null,
                SerializedPropertyType.String => string.IsNullOrEmpty(property.stringValue),
                _ => false
            };
        }
    }
}
