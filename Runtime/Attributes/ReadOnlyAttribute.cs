using System;
using UnityEngine;

namespace UnityUtils.Attributes
{
    /// <summary>
    /// Makes a field read-only in the inspector, but still editable in code.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class ReadOnlyAttribute : PropertyAttribute { }
}
