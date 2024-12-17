using System;
using UnityEngine;

namespace Utils.Attributes
{
    /// <summary>
    /// Define a field as required in the inspector. If the field is not set, a warning will be displayed in both the inspector and the hierarchy.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class RequiredFieldAttribute : PropertyAttribute { }
}
