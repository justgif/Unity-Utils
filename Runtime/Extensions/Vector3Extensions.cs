using UnityEngine;

namespace Utils.Extensions
{
    public static class Vector3Extensions
    {
        /// <summary>
        /// Adds the specified values to the vector.
        /// </summary>
        /// <param name="vector">The vector to add to.</param>
        /// <param name="x">The value to add to the x component of the vector. Default is 0.</param>
        /// <param name="y">The value to add to the y component of the vector. Default is 0.</param>
        /// <param name="z">The value to add to the z component of the vector. Default is 0.</param>
        /// <returns>The resulting vector after addition.</returns>
        public static Vector3 Add(this Vector3 vector, float x = 0, float y = 0, float z = 0)
        {
            return new(vector.x + x, vector.y + y, vector.z + z);
        }

        /// <summary>
        /// Checks if the vector is within a specified range of another vector.
        /// </summary>
        /// <param name="origin">The vector to check.</param>
        /// <param name="target">The target vector to compare against.</param>
        /// <param name="range">The range within which the vectors are considered to be in range.</param>
        /// <returns>True if the vector is within the specified range of the target vector, otherwise false.</returns>
        public static bool InRangeOf(this Vector3 origin, Vector3 target, float range)
        {
            return (origin - target).sqrMagnitude <= range * range;
        }

        /// <summary>
        /// Creates a new vector with optional component values.
        /// </summary>
        /// <param name="vector">The original vector.</param>
        /// <param name="x">The new value for the x component. If null, the original value is used.</param>
        /// <param name="y">The new value for the y component. If null, the original value is used.</param>
        /// <param name="z">The new value for the z component. If null, the original value is used.</param>
        /// <returns>A new vector with the specified component values.</returns>
        public static Vector3 With(this Vector3 vector, float? x = null, float? y = null, float? z = null)
        {
            return new(x ?? vector.x, y ?? vector.y, z ?? vector.z);
        }
    }
}
