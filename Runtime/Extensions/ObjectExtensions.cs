using UnityEngine;

namespace Utils.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Returns the object if it is not null, otherwise returns null.
        /// </summary>
        /// <remarks>
        /// This method allows for Unity objects to be checked for proper null, meaning they can use null-conditional and null-coalescing operators.
        /// </remarks>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="obj">The object to check.</param>
        /// <returns>The object if it is not null, otherwise null.</returns>
        public static T OrNull<T>(this T obj) where T : Object
        {
            return obj ? obj : null;
        }
    }
}
