// ********************************
// <copyright file="Methods.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Utilities
{
    using System;

    /// <summary>
    /// Stores examples for High Quality Methods.
    /// </summary>
    public static class Methods
    {
        /// <summary>
        /// Calculates triangle area by given three sides.
        /// </summary>
        /// <remarks>
        /// Uses Heron's formula. 
        /// <seealso cref="http://en.wikipedia.org/wiki/Heron's_formula"/>
        /// </remarks>
        /// <param name="a">Side "a" size.</param>
        /// <param name="b">Side "b" size.</param>
        /// <param name="c">Side "c" size.</param>
        /// <returns>The calculated area.</returns>
        /// <example>
        /// Sample usage:
        /// <code>
        /// public slass TestClass{
        ///     double sampleArea = Methods.CalculateTriangleArea(2, 3, 4);
        /// }
        /// </code>
        /// </example>
        public static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0)
            {
                throw new ArgumentOutOfRangeException("Side \"a\" size must be positive!");
            }

            if (b <= 0)
            {
                throw new ArgumentOutOfRangeException("Side \"b\" size must be positive!");
            }

            if (c <= 0)
            {
                throw new ArgumentOutOfRangeException("Side \"c\" size must be positive!");
            }

            double perimeter = a + b + c;
            double semiPerimeter = perimeter / 2;
            double area = Math.Sqrt(semiPerimeter * ((semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c)));

            return area;
        }

        /// <summary>
        /// Converts integer number to its english string representation.
        /// </summary>
        /// <param name="number">Integer in range [0,9].</param>
        /// <returns>The string representation of the input number.</returns>
        /// <example>
        /// Sample usage:
        /// <code>
        /// public slass TestClass{
        ///     double numberAsString = Methods.ConvertDigitToString(2);
        /// }
        /// </code>
        /// </example>
        public static string ConvertDigitToString(int number)
        {
            switch (number)
            {
                case 0:
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    throw new ArgumentOutOfRangeException("Input number must be in range [0,9]!");
            }
        }

        /// <summary>
        /// Finds the biggest element.
        /// </summary>
        /// <param name="elements">Input elements.</param>
        /// <returns>The biggest element.</returns>
        /// <example>
        /// Sample usage:
        /// <code>
        /// public slass TestClass{
        ///     int theOne = Methods.Max(2,5,-3,12);
        /// }
        /// </code>
        /// </example>
        public static int Max(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("Input elements are null!");
            }

            if (elements.Length == 0)
            {
                throw new ArgumentException("There are no input elements!");
            }

            int max = int.MinValue;

            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] > max)
                {
                    max = elements[i];
                }
            }

            return max;
        }

        /// <summary>
        /// Prints given number with given decimal precision.
        /// </summary>
        /// <param name="number">Input number</param>
        /// <param name="precision">Decimal precision</param>
        /// <example>
        /// Sample usage:
        /// <code>
        /// public slass TestClass{
        ///     PrintAsNumber(1.2,2);
        /// }
        /// </code>
        /// </example>
        public static void PrintAsNumber(double number, int precision = 2)
        {
            string numberFormat = "{0:f" + precision + "}";
            Console.WriteLine(numberFormat, number);
        }

        /// <summary>
        /// Prints input number as a percent.
        /// </summary>
        /// <param name="number">Input number</param>
        /// <param name="precision">Decimal Precision</param>
        /// <example>
        /// Sample usage:
        /// <code>
        /// public slass TestClass{
        ///     PrintAsPercent(0.12,2);
        /// }
        /// </code>
        /// </example>
        public static void PrintAsPercent(double number, int precision = 0)
        {
            string numberFormat = "{0:p" + precision + "}";
            Console.WriteLine(numberFormat, number);
        }

        /// <summary>
        /// Prints input data padded (left/right) in the specified total length. Adds additional padding spaces.
        /// </summary>
        /// <param name="value">Input data.</param>
        /// <param name="length">Total length.</param>
        /// <example>
        /// Sample usage:
        /// <code>
        /// public slass TestClass{
        ///     PrintAlligned(1.234,10);
        /// }
        /// </code>
        /// </example>
        public static void PrintAlligned(object value, int length = 8)
        {
            string numberFormat = "{0," + length + "}";
            Console.WriteLine(numberFormat, value);
        }

        /// <summary>
        /// Calculates distance between two points specified by their coordinates in 2D Euclidean plane.
        /// </summary>
        /// <param name="x1">The x-coordinate of the first point.</param>
        /// <param name="y1">The y-coordinate of the first point.</param>
        /// <param name="x2">The x-coordinate of the second point.</param>
        /// <param name="y2">The y-coordinate of the second point.</param>
        /// <returns>The distance between the two points.</returns>
        /// <example>
        /// Sample usage:
        /// <code>
        /// public slass TestClass{
        ///     double sampleDistance = CalcDistance(3, -1, 3, 2.5);
        /// }
        /// </code>
        /// </example>
        public static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
            return distance;
        }

        /// <summary>
        /// Checks if two points specified by their coordinates in 2D Euclidean plane form one horizontal line.
        /// </summary>
        /// <param name="x1">The x-coordinate of the first point.</param>
        /// <param name="y1">The y-coordinate of the first point.</param>
        /// <param name="x2">The x-coordinate of the second point.</param>
        /// <param name="y2">The y-coordinate of the second point.</param>
        /// <returns>True if the two points form horizontal line.</returns>
        /// <example>
        /// Sample usage:
        /// <code>
        /// public slass TestClass{
        ///     bool isHorizontalLine = FormHorizontalLine(3, -1, 3, 2.5);
        /// }
        /// </code>
        /// </example>
        public static bool FormHorizontalLine(double x1, double y1, double x2, double y2)
        {
            if (PointsCoincide(x1, y1, x2, y2))
            {
                throw new ArgumentException("X is the same as Y!");
            }

            return y1 == y2;
        }

        /// <summary>
        /// Checks if two points specified by their coordinates in 2D Euclidean plane form one vertical line.
        /// </summary>
        /// <param name="x1">The x-coordinate of the first point.</param>
        /// <param name="y1">The y-coordinate of the first point.</param>
        /// <param name="x2">The x-coordinate of the second point.</param>
        /// <param name="y2">The y-coordinate of the second point.</param>
        /// <returns>True if the two points form vertical line.</returns>
        /// <example>
        /// Sample usage:
        /// <code>
        /// public slass TestClass{
        ///     bool isVerticalLine = FormVerticalLine(3, -1, 3, 2.5);
        /// }
        /// </code>
        /// </example>
        public static bool FormVerticalLine(double x1, double y1, double x2, double y2)
        {
            if (PointsCoincide(x1, y1, x2, y2))
            {
                throw new ArgumentException("X is the same as Y!");
            }

            return x1 == x2;
        }

        /// <summary>
        /// Checks if two points specified by their coordinates in 2D Euclidean have the same coordinates.
        /// </summary>
        /// <param name="x1">The x-coordinate of the first point.</param>
        /// <param name="y1">The y-coordinate of the first point.</param>
        /// <param name="x2">The x-coordinate of the second point.</param>
        /// <param name="y2">The y-coordinate of the second point.</param>
        /// <returns>True if the points coincide.</returns>
        /// <example>
        /// Sample usage:
        /// <code>
        /// public slass TestClass{
        ///     bool isPointsCoincide = PointsCoincide(3, -1, 3, 2.5);
        /// }
        /// </code>
        /// </example>
        public static bool PointsCoincide(double x1, double y1, double x2, double y2)
        {
            return x1 == x2 && y1 == y2;
        }

        /// <summary>
        /// Program entry point.
        /// </summary>
        private static void Main()
        {
            try
            {
                Console.WriteLine(CalculateTriangleArea(3, 4, 5));

                Console.WriteLine(ConvertDigitToString(5));

                Console.WriteLine(Max(5, -1, 3, 2, 14, 2, 3));

                PrintAsNumber(1.3);
                PrintAsPercent(0.75,-10);
                PrintAlligned(2.30);
                PrintAlligned(1.234, 10);
                Console.WriteLine(CalcDistance(3, -1, 3, 2.5));
                Console.WriteLine("Horizontal? " + FormHorizontalLine(3, -1, 3, 2.5));
                Console.WriteLine("Vertical? " + FormVerticalLine(3, -1, 3, 2.5));

                Student peter = new Student("Peter", "Ivanov", "Sofia", DateTime.Parse("17.03.1992"));

                Student stella = new Student("Stella", "Markova", "Vidin", DateTime.Parse("03.11.1993"), "Gamer, high results.");

                Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
            }
        }
    }
}