using System;
using UnityEngine;

namespace Utils.Attributes
{
    /// <summary>
    /// Adds a button in the inspector that invokes the attached method when clicked.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class MethodButtonAttribute : PropertyAttribute
    {
        /// <summary>
        /// Whether the game needs to be running in play mode for the method to be invoked.
        /// </summary>
        public bool RequiresGameRunning { get; set; } = true;
    }
}
