using System.Collections.Generic;
using System;

namespace Utils.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Performs the specified action on each element of the IEnumerable.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the IEnumerable.</typeparam>
        /// <param name="items">The IEnumerable to iterate over.</param>
        /// <param name="action">The action to perform on each element.</param>
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (T item in items)
            {
                action(item);
            }
        }

        /// <summary>
        /// Performs the specified action on each element of the IEnumerable, passing the index of the element as a parameter to the action.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the IEnumerable.</typeparam>
        /// <param name="items">The IEnumerable to iterate over.</param>
        /// <param name="action">The action to perform on each element. The second parameter of the action represents the index of the element.</param>
        public static void ForEachIndex<T>(this IEnumerable<T> items, Action<T, int> action)
        {
            int index = 0;
            foreach (T item in items)
            {
                action(item, index);
                index++;
            }
        }

        /// <summary>
        /// Iterates over each element of the IEnumerable until the specified condition is met.
        /// Performs the specified action on the element that meets the condition, then breaks out of the loop.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the IEnumerable.</typeparam>
        /// <param name="items">The IEnumerable to iterate over.</param>
        /// <param name="condition">The condition to check for each element. The iteration stops when this condition is met.</param>
        /// <param name="action">The action to perform on the element that meets the condition.</param>
        public static void ForEachUntil<T>(this IEnumerable<T> items, Func<T, bool> condition, Action<T> action)
        {
            foreach (T item in items)
            {
                if (!condition(item))
                    continue;
                
                action(item);
                break;
            }
        }
    }
}
