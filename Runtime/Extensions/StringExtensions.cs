using System.Linq;

namespace Utils.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Determines whether the specified string consists only of alphabetic characters.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns><c>true</c> if the string consists only of alphabetic characters, otherwise <c>false</c>.</returns>
        public static bool IsAlpha(this string value)
        {
            return !string.IsNullOrEmpty(value) && value.All(char.IsLetter);
        }

        /// <summary>
        /// Determines whether the specified string consists only of alphanumeric characters.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns><c>true</c> if the string consists only of alphanumeric characters, otherwise <c>false</c>.</returns>
        public static bool IsAlphanumeric(this string value)
        {
            return !string.IsNullOrEmpty(value) && value.All(char.IsLetterOrDigit);
        }

        /// <summary>
        /// Determines whether the specified string consists only of numeric characters.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns><c>true</c> if the string consists only of numeric characters, otherwise <c>false</c>.</returns>
        public static bool IsNumeric(this string value)
        {
            return !string.IsNullOrEmpty(value) && value.All(char.IsDigit);
        }

        /// <summary>
        /// Returns the specified string or an empty string if it is null.
        /// </summary>
        /// <param name="value">The string to return or check.</param>
        /// <returns>The specified string or an empty string if it is null.</returns>
        public static string OrEmpty(this string value)
        {
            return value ?? string.Empty;
        }

        /// <summary>
        /// Removes all non-alphabetic characters from the specified string.
        /// </summary>
        /// <param name="value">The string to remove non-alphabetic characters from.</param>
        /// <returns>The specified string with all non-alphabetic characters removed.</returns>
        public static string RemoveNonAlpha(this string value)
        {
            return string.IsNullOrEmpty(value) ? value : new string(value.Where(char.IsLetter).ToArray());
        }

        /// <summary>
        /// Removes all non-alphanumeric characters from the specified string.
        /// </summary>
        /// <param name="value">The string to remove non-alphanumeric characters from.</param>
        /// <returns>The specified string with all non-alphanumeric characters removed.</returns>
        public static string RemoveNonAlphanumeric(this string value)
        {
            return string.IsNullOrEmpty(value) ? value : new string(value.Where(char.IsLetterOrDigit).ToArray());
        }

        /// <summary>
        /// Removes all non-numeric characters from the specified string.
        /// </summary>
        /// <param name="value">The string to remove non-numeric characters from.</param>
        /// <returns>The specified string with all non-numeric characters removed.</returns>
        public static string RemoveNonNumeric(this string value)
        {
            return string.IsNullOrEmpty(value) ? value : new string(value.Where(char.IsDigit).ToArray());
        }
    }
}
