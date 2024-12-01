using UnityEditor;
using UnityEngine;
using Utils.Attributes;

namespace Utils.Editor.Drawers
{
    [CustomPropertyDrawer(typeof(Vector2RangeAttribute))]
    public class Vector2RangeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            Vector2RangeAttribute range = (Vector2RangeAttribute)attribute;

            label.tooltip = $"{range.Min:F2} to {range.Max:F2}";

            Rect[] splitRect = SplitRect(EditorGUI.PrefixLabel(position, label), 3);

            switch (property.propertyType)
            {
                case SerializedPropertyType.Vector2:
                    Vector2ChangeCheck(property, range, splitRect);
                    break;
                case SerializedPropertyType.Vector2Int:
                    Vector2IntChangeCheck(property, range, splitRect);
                    break;
            }
        }

        private static Rect[] SplitRect(Rect rect, int n)
        {
            Rect[] rects = new Rect[n];
            float width = rect.width / n;

            for (int i = 0; i < n; i++)
            {
                rects[i] = new Rect(rect.position.x + (i * width), rect.position.y, width, rect.height);
            }

            int padding = (int)rects[0].width - 40;
            const int space = 5;

            rects[0].width -= padding + space;
            rects[1].x -= padding;
            rects[1].width += padding * 2;
            rects[2].x += padding + space;
            rects[2].width -= padding + space;

            return rects;
        }

        private static void Vector2ChangeCheck(SerializedProperty property, Vector2RangeAttribute range, Rect[] splitRect)
        {
            EditorGUI.BeginChangeCheck();

            Vector2 vector = property.vector2Value;
            float min = vector.x;
            float max = vector.y;

            min = EditorGUI.FloatField(splitRect[0], float.Parse(min.ToString("F2")));
            max = EditorGUI.FloatField(splitRect[2], float.Parse(max.ToString("F2")));

            EditorGUI.MinMaxSlider(splitRect[1], ref min, ref max, range.Min, range.Max);

            min = Mathf.Max(min, range.Min);
            max = Mathf.Min(max, range.Max);
            vector = new Vector2(min > max ? max : min, max);

            if (EditorGUI.EndChangeCheck())
            {
                property.vector2Value = vector;
            }
        }

        private static void Vector2IntChangeCheck(SerializedProperty property, Vector2RangeAttribute range, Rect[] splitRect)
        {
            EditorGUI.BeginChangeCheck();

            Vector2Int vector = property.vector2IntValue;
            float min = vector.x;
            float max = vector.y;

            min = EditorGUI.FloatField(splitRect[0], min);
            max = EditorGUI.FloatField(splitRect[2], max);

            EditorGUI.MinMaxSlider(splitRect[1], ref min, ref max, range.Min, range.Max);

            min = Mathf.Max(min, range.Min);
            max = Mathf.Min(max, range.Max);
            vector = new Vector2Int(Mathf.FloorToInt(min > max ? max : min), Mathf.FloorToInt(max));

            if (EditorGUI.EndChangeCheck())
            {
                property.vector2IntValue = vector;
            }
        }
    }
}
