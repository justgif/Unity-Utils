using UnityEngine;

namespace Utils.Extensions
{
    public static class Vector2Extensions
    {
        /// <summary>
        /// Adds the specified values to the vector.
        /// </summary>
        /// <param name="vector">The vector to add to.</param>
        /// <param name="x">The value to add to the x component of the vector. Default is 0.</param>
        /// <param name="y">The value to add to the y component of the vector. Default is 0.</param>
        /// <returns>The resulting vector after addition.</returns>
        public static Vector2 Add(this Vector2 vector, float x = 0, float y = 0)
        {
            return new(vector.x + x, vector.y + y);
        }

        /// <summary>
        /// Checks if the vector is within a specified range of another vector.
        /// </summary>
        /// <param name="origin">The origin vector.</param>
        /// <param name="target">The target vector to compare with.</param>
        /// <param name="range">The range within which the vectors are considered to be in range.</param>
        /// <returns>True if the vector is within the specified range, otherwise false.</returns>
        public static bool InRangeOf(this Vector2 origin, Vector2 target, float range)
        {
            return (origin - target).sqrMagnitude <= range * range;
        }

        /// <summary>
        /// Generates a random float value within the range defined by the vector's components.
        /// </summary>
        /// <param name="vector">The vector defining the range.</param>
        /// <returns>A random float value within the range.</returns>
        public static float RandomInRange(this Vector2 vector)
        {
            return Random.Range(vector.x, vector.y);
        }

        /// <summary>
        /// Generates a random integer value within the range defined by the vector's components.
        /// </summary>
        /// <param name="vector">The vector defining the range.</param>
        /// <returns>A random integer value within the range.</returns>
        public static int RandomInRange(this Vector2Int vector)
        {
            return Random.Range(vector.x, vector.y);
        }

        /// <summary>
        /// Creates a new vector with optional new component values.
        /// </summary>
        /// <param name="vector">The original vector.</param>
        /// <param name="x">The new value for the x component. If null, the original value is used.</param>
        /// <param name="y">The new value for the y component. If null, the original value is used.</param>
        /// <returns>A new vector with optional new component values.</returns>
        public static Vector2 With(this Vector2 vector, float? x = null, float? y = null)
        {
            return new(x ?? vector.x, y ?? vector.y);
        }
    }
}
