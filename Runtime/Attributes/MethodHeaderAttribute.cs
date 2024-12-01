using System;
using UnityEngine;

namespace UnityUtils.Attributes
{
    /// <summary>
    /// Adds a header above a <see cref="MethodButtonAttribute"/> in the inspector.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class MethodHeaderAttribute : PropertyAttribute
    {
        public string Header { get; private set; }

        public MethodHeaderAttribute(string header)
        {
            Header = header;
        }
    }
}
