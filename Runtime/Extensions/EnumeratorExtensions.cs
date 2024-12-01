using System.Collections.Generic;

namespace Utils.Extensions
{
    public static class EnumeratorExtensions
    {
        /// <summary>
        /// Converts an IEnumerator to an IEnumerable.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the enumerator.</typeparam>
        /// <param name="enumerator">The IEnumerator to convert.</param>
        /// <returns>An IEnumerable containing the elements of the enumerator.</returns>
        public static IEnumerable<T> ToEnumerable<T>(this IEnumerator<T> enumerator)
        {
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }
    }
}
