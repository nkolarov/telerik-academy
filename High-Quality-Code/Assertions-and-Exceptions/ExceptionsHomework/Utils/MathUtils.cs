// ********************************
// <copyright file="MathUtils.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace ExceptionsHomework.Utils
{
    using System;

    /// <summary>
    /// Stores Mathematical utilities.
    /// </summary>
    public static class MathUtils
    {
        /// <summary>
        /// Checks if given number is prime.
        /// </summary>
        /// <param name="number">The input number.</param>
        /// <returns>True if input number is prime.</returns>
        public static bool CheckIfPrime(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentOutOfRangeException("number", "Input number must be positive and greater than 0!");
            }

            for (int divisor = 1; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}