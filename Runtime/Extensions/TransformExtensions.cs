using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

namespace Utils.Extensions
{
    public static class TransformExtensions
    {
        /// <summary>
        /// Returns an enumerable collection of the children of the specified parent transform.
        /// </summary>
        /// <param name="parent">The parent transform.</param>
        /// <returns>An enumerable collection of the children of the parent transform.</returns>
        public static IEnumerable<Transform> Children(this Transform parent)
        {
            return parent.Cast<Transform>();
        }

        /// <summary>
        /// Performs the specified action on each child transform of the specified parent transform.
        /// </summary>
        /// <param name="parent">The parent transform.</param>
        /// <param name="action">The action to perform on each child transform.</param>
        public static void ForEachChild(this Transform parent, Action<Transform> action)
        {
            foreach (Transform child in parent)
            {
                action(child);
            }
        }

        /// <summary>
        /// Determines whether the specified origin transform is within the specified range of the target transform.
        /// </summary>
        /// <param name="origin">The origin transform.</param>
        /// <param name="target">The target transform.</param>
        /// <param name="maxDistance">The maximum distance between the origin and target transforms.</param>
        /// <param name="maxAngle">The maximum angle (in degrees) between the origin's forward direction and the direction towards the target transform.</param>
        /// <returns><c>true</c> if the origin transform is within range of the target transform; otherwise, <c>false</c>.</returns>
        public static bool InRangeOf(this Transform origin, Transform target, float maxDistance, float maxAngle = 360f)
        {
            Vector3 direction = (target.position - origin.position).With(y: 0);
            return direction.magnitude <= maxDistance && Vector3.Angle(origin.forward, direction) <= maxAngle / 2;
        }

        /// <summary>
        /// Resets the local position, rotation, and scale of the specified transform.
        /// </summary>
        /// <param name="transform">The transform to reset.</param>
        public static void Reset(this Transform transform)
        {
            transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            transform.localScale = Vector3.one;
        }

        /// <summary>
        /// Resets the local position and rotation of the specified transform.
        /// </summary>
        /// <param name="transform">The transform to reset.</param>
        public static void ResetPositionAndRotation(this Transform transform)
        {
            transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        }
    }
}
