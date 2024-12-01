using System;
using UnityEngine;

namespace Utils.Attributes
{
    /// <summary>
    /// Define a <see cref="Vector2"/> or <see cref="Vector2Int"/> field as a min-max range and displays it as a slider in the inspector.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class Vector2RangeAttribute : PropertyAttribute
    {
        public float Min { get; private set; }
        public float Max { get; private set; }

        public Vector2RangeAttribute(float min, float max)
        {
            Min = min;
            Max = max;
        }
    }
}
