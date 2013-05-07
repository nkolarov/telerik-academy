// ********************************
// <copyright file="StringUtils.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace ExceptionsHomework.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Stores String utilities.
    /// </summary>
    public static class StringUtils
    {
        /// <summary>
        /// Gets a subsequence from the specified input sequence by given count and start index.
        /// </summary>
        /// <param name="sequence">The input sequence.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="count">The count.</param>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <returns>The subsequence.</returns>
        public static T[] Subsequence<T>(T[] sequence, int startIndex, int count)
        {
            if (sequence == null)
            {
                throw new ArgumentNullException("arr", "Input sequence must not be null!");
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException("startIndex", "Start Index must be positive!");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count", "Elements count must be positive!");
            }

            if (startIndex > sequence.Length - 1)
            {
                throw new ArgumentOutOfRangeException("startIndex", "Start index must not be greater than the size of the input sequence!");
            }

            List<T> result = new List<T>();
            for (int i = startIndex; i < startIndex + count; i++)
            {
                result.Add(sequence[i]);
            }

            return result.ToArray();
        }

        /// <summary>
        /// Extracts a substring by given length starting from the end to the beginning of the string.
        /// </summary>
        /// <param name="str">The input string.</param>
        /// <param name="count">The length of the substring that has to be extracted.</param>
        /// <returns>The substring.</returns>
        public static string ExtractEnding(string str, int count)
        {
            if (str == null)
            {
                throw new ArgumentNullException("str", "Input string must not be null!");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count", "Elements count must be positive!");
            }

            if (count > str.Length - 1)
            {
                throw new ArgumentOutOfRangeException("count", "Elements count must not be greater than the size of the input string!");
            }

            StringBuilder result = new StringBuilder();
            for (int i = str.Length - count; i < str.Length; i++)
            {
                result.Append(str[i]);
            }

            return result.ToString();
        }
    }
}