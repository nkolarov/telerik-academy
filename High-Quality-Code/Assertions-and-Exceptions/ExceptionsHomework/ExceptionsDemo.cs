// ********************************
// <copyright file="ExceptionsDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace ExceptionsHomework
{
    using System;
    using System.Collections.Generic;
    using Utils;

    /// <summary>
    /// Just a demonstration of correct exceptions usage.
    /// </summary>
    public class ExceptionsDemo
    {
        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            try
            {
                var substr = StringUtils.Subsequence("Hello!".ToCharArray(), 2, 3);
                Console.WriteLine(substr);

                var subarr = StringUtils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
                Console.WriteLine(string.Join(" ", subarr));

                var allarr = StringUtils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
                Console.WriteLine(string.Join(" ", allarr));

                var emptyarr = StringUtils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
                Console.WriteLine(string.Join(" ", emptyarr));
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine(ane.Message);
            }
            catch (ArgumentOutOfRangeException aore)
            {
                Console.WriteLine(aore.Message);
            }

            try
            {
                Console.WriteLine(StringUtils.ExtractEnding("I love C#", 2));
                Console.WriteLine(StringUtils.ExtractEnding("Nakov", 4));
                Console.WriteLine(StringUtils.ExtractEnding("beer", 4));
                Console.WriteLine(StringUtils.ExtractEnding("Hi", 100));
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine(ane.Message);
            }
            catch (ArgumentOutOfRangeException aore)
            {
                Console.WriteLine(aore.Message);
            }

            try
            {
                int[] numbersToCheck = new int[] { 23, 33, 1, 0 };

                for (int i = 0; i < numbersToCheck.Length; i++)
                {
                    bool isPrime = MathUtils.CheckIfPrime(numbersToCheck[i]);
                    Console.WriteLine("{0} {1} prime.", numbersToCheck[i], isPrime ? "is" : "is NOT");
                }
            }
            catch (ArgumentOutOfRangeException aore)
            {
                Console.WriteLine(aore.Message);
            }

            try
            {
                List<Exam> peterExams = new List<Exam>()
                {
                    new SimpleMathExam(2),
                    new CSharpExam(55, 0, 100),
                    new CSharpExam(100, 0, 100),
                    new SimpleMathExam(1),
                    new CSharpExam(0, 0, 100),
                };
                Student peter = new Student("Peter", "Petrov", peterExams);
                double peterAverageResult = peter.CalcAverageResultInPercent();
                Console.WriteLine("Average results = {0:p0}", peterAverageResult);

                peterExams.Add(new CSharpExam(550, 0, 100));
            }
            catch (ArgumentOutOfRangeException aore)
            {
                Console.WriteLine(aore.Message);
            }
        }
    }
}