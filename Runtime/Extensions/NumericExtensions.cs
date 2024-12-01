using System;
using UnityEngine;

namespace Utils.Extensions
{
    public static class NumberExtensions
    {
        /// <summary>
        /// Returns the absolute value of a float number.
        /// </summary>
        /// <param name="value">The float number.</param>
        /// <returns>The absolute value of the float number.</returns>
        public static float Abs(this float value)
        {
            return Mathf.Abs(value);
        }

        /// <summary>
        /// Returns the absolute value of an integer number.
        /// </summary>
        /// <param name="value">The integer number.</param>
        /// <returns>The absolute value of the integer number.</returns>
        public static int Abs(this int value)
        {
            return Mathf.Abs(value);
        }

        /// <summary>
        /// Checks if two float numbers are approximately equal.
        /// </summary>
        /// <param name="a">The first float number.</param>
        /// <param name="b">The second float number.</param>
        /// <returns>True if the float numbers are approximately equal, false otherwise.</returns>
        public static bool Approx(this float a, float b)
        {
            return Mathf.Approximately(a, b);
        }

        /// <summary>
        /// Returns the maximum value between a float number and a minimum value.
        /// </summary>
        /// <param name="value">The float number.</param>
        /// <param name="min">The minimum value.</param>
        /// <returns>The maximum value between the float number and the minimum value.</returns>
        public static float AtLeast(this float value, float min)
        {
            return Mathf.Max(value, min);
        }

        /// <summary>
        /// Returns the maximum value between an integer number and a minimum value.
        /// </summary>
        /// <param name="value">The integer number.</param>
        /// <param name="min">The minimum value.</param>
        /// <returns>The maximum value between the integer number and the minimum value.</returns>
        public static int AtLeast(this int value, int min)
        {
            return Mathf.Max(value, min);
        }

        /// <summary>
        /// Returns the minimum value between a float number and a maximum value.
        /// </summary>
        /// <param name="value">The float number.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>The minimum value between the float number and the maximum value.</returns>
        public static float AtMost(this float value, float max)
        {
            return Mathf.Min(value, max);
        }

        /// <summary>
        /// Returns the minimum value between an integer number and a maximum value.
        /// </summary>
        /// <param name="value">The integer number.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>The minimum value between the integer number and the maximum value.</returns>
        public static int AtMost(this int value, int max)
        {
            return Mathf.Min(value, max);
        }

        /// <summary>
        /// Executes the specified action a specified number of times.
        /// </summary>
        /// <param name="count">The number of times to execute the action.</param>
        /// <param name="action">The action to execute.</param>
        public static void For(this int count, Action<int> action)
        {
            for (int i = 0; i < count; i++)
            {
                action(i);
            }
        }

        /// <summary>
        /// Checks if an integer number is even.
        /// </summary>
        /// <param name="x">The integer number.</param>
        /// <returns>True if the integer number is even, false otherwise.</returns>
        public static bool IsEven(this int x)
        {
            return x % 2 == 0;
        }

        /// <summary>
        /// Checks if an integer number is odd.
        /// </summary>
        /// <param name="x">The integer number.</param>
        /// <returns>True if the integer number is odd, false otherwise.</returns>
        public static bool IsOdd(this int x)
        {
            return x % 2 == 1;
        }

        /// <summary>
        /// Calculates the percentage of a float number relative to a whole number.
        /// </summary>
        /// <param name="part">The float number representing the part.</param>
        /// <param name="whole">The float number representing the whole.</param>
        /// <returns>The percentage of the part relative to the whole.</returns>
        public static float PercentageOf(this float part, float whole)
        {
            return whole == 0 ? 0 : part / whole;
        }

        /// <summary>
        /// Calculates the percentage of an integer number relative to a whole number.
        /// </summary>
        /// <param name="part">The integer number representing the part.</param>
        /// <param name="whole">The integer number representing the whole.</param>
        /// <returns>The percentage of the part relative to the whole.</returns>
        public static float PercentageOf(this int part, int whole)
        {
            return whole == 0 ? 0 : (float)part / whole;
        }
    }
}
