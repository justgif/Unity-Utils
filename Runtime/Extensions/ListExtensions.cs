using System.Collections.Generic;
using System.Linq;

namespace Utils.Extensions
{
    public static class ListExtensions
    {
        /// <summary>
        /// Creates a copy of the list.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list to clone.</param>
        /// <returns>A new list that is a copy of the original list.</returns>
        public static List<T> Clone<T>(this IList<T> list)
        {
            return list.ToList();
        }

        /// <summary>
        /// Checks if the list is null or empty.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list to check.</param>
        /// <returns>True if the list is null or empty, false otherwise.</returns>
        public static bool IsNullOrEmpty<T>(this IList<T> list)
        {
            return list == null || list.Count == 0;
        }

        /// <summary>
        /// Swaps the elements at the specified indices in the list.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list in which to swap elements.</param>
        /// <param name="indexA">The index of the first element to swap.</param>
        /// <param name="indexB">The index of the second element to swap.</param>
        public static void Swap<T>(this IList<T> list, int indexA, int indexB)
        {
            (list[indexA], list[indexB]) = (list[indexB], list[indexA]);
        }
    }
}
