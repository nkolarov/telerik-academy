// ********************************
// <copyright file="MinimumEditDistance.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace DynamicProgramming
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Demonstrates the solving of minimum edit distance problem.
    /// </summary>
    public class MinimumEditDistance
    {
        /* 02. Write a program to calculate the "Minimum Edit Distance" (MED) between two words. MED(x, y) is the minimal sum of costs of edit operations used to transform x to y. Sample costs are given below:
        cost (replace a letter) = 1
        cost (delete a letter) = 0.9
        cost (insert a letter) = 0.8
        Example: x = "developer", y = "enveloped" -> cost = 2.7 
        delete ‘d’:  "developer" -> "eveloper", cost = 0.9
        insert ‘n’:  "eveloper" -> "enveloper", cost = 0.8
        replace ‘r’  ‘d’:  "enveloper" -> "enveloped", cost = 1 */

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            List<Tuple<string, string>> words = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("developer", "enveloped"),
                new Tuple<string, string>("developer", "eveloper"),
                new Tuple<string, string>("eveloper", "enveloper"),
                new Tuple<string, string>("enveloper", "enveloped")
            };

            for (int i = 0; i < words.Count; i++)
            {
                string firstWord = words[i].Item1;
                string secondWord = words[i].Item2;
                Console.WriteLine("x = {0}, y= {1} -> Cost: {2}", firstWord, secondWord, GetMinimumEditDistanceCosts(firstWord, secondWord));     
            }
        }

        /// <summary>
        /// Gets the minimum edit distance costs.
        /// </summary>
        /// <param name="firstString">The first string.</param>
        /// <param name="secondString">The second string.</param>
        /// <returns>The costs.</returns>
        public static double GetMinimumEditDistanceCosts(string firstString, string secondString)
        {
            double result = 0;

            // Gets the Longest Common Substring, because it will not be changed
            string longestCommonSubstr = LongestCommonSubstring(firstString, secondString);

            if (longestCommonSubstr == string.Empty || longestCommonSubstr.Length == 0)
            {
                // There is no common substring. Calculate everything.
                if (firstString.Length == secondString.Length)
                {
                    // Change all letters.
                    result = firstString.Length; 
                }
                else if (firstString.Length > secondString.Length)
                {
                    // Delete the letters and change the remainings.
                    var removedLettersCost = (firstString.Length - secondString.Length) * 0.9;
                    result = removedLettersCost + secondString.Length; 
                }
                else
                {
                    // Insert new letters and change the remainings.
                    var insertedLettersCost = (secondString.Length - firstString.Length) * 0.8;
                    result = insertedLettersCost + firstString.Length; 
                }
            }
            else
            {
                // Get prefixes and sufixes and calculate their costs.
                int lcsindexFirstString = firstString.IndexOf(longestCommonSubstr);
                int lcsIndexSecondString = secondString.IndexOf(longestCommonSubstr);

                string firstStringPrefix = firstString.Substring(0, lcsindexFirstString);
                string secondStringPrefix = secondString.Substring(0, lcsIndexSecondString);

                string firstStringdSufix = firstString.Substring(lcsindexFirstString + longestCommonSubstr.Length);
                string secondStringSufix = secondString.Substring(lcsIndexSecondString + longestCommonSubstr.Length);

                result = GetMinimumEditDistanceCosts(firstStringPrefix, secondStringPrefix) + GetMinimumEditDistanceCosts(firstStringdSufix, secondStringSufix);
            }

            return result;
        }

        /// <summary>
        /// Gets the longest common substring using this algorithm: http://en.wikibooks.org/wiki/Algorithm_implementation/Strings/Longest_common_substring
        /// </summary>
        /// <param name="firstString">The first string.</param>
        /// <param name="secondString">The second string.</param>
        /// <returns>The longest common substring.</returns>
        public static string LongestCommonSubstring(string firstString, string secondString)
        {
            if (string.IsNullOrEmpty(firstString) || string.IsNullOrEmpty(secondString))
            {
                return string.Empty;
            }

            int[,] num = new int[firstString.Length, secondString.Length];
            int maxlen = 0;
            int lastSubsBegin = 0;
            StringBuilder sequenceBuilder = new StringBuilder();

            for (int i = 0; i < firstString.Length; i++)
            {
                for (int j = 0; j < secondString.Length; j++)
                {
                    if (firstString[i] != secondString[j])
                    {
                        num[i, j] = 0;
                    }
                    else
                    {
                        if ((i == 0) || (j == 0))
                        {
                            num[i, j] = 1;
                        }
                        else
                        {
                            num[i, j] = 1 + num[i - 1, j - 1];
                        }

                        if (num[i, j] > maxlen)
                        {
                            maxlen = num[i, j];
                            int thisSubsBegin = i - num[i, j] + 1;
                            if (lastSubsBegin == thisSubsBegin)
                            { 
                                // If the current LCS is the same as the last time this block ran
                                sequenceBuilder.Append(firstString[i]);
                            }
                            else 
                            {
                                // this block resets the string builder if a different LCS is found
                                lastSubsBegin = thisSubsBegin;

                                // Clear it
                                sequenceBuilder.Length = 0; 
                                sequenceBuilder.Append(firstString.Substring(lastSubsBegin, (i + 1) - lastSubsBegin));
                            }
                        }
                    }
                }
            }
            
            return sequenceBuilder.ToString();
        }
    }
}