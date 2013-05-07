// ********************************
// <copyright file="AssertionsDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace AssertionsHomework
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    
    /// <summary>
    /// Demonstrates correct assertions usage.
    /// </summary>
    public class AssertionsDemo
    {
        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
            Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
            SelectionSort(arr);
            Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

            SelectionSort(new int[0]); // Test sorting empty array
            SelectionSort(new int[1]); // Test sorting single element array

            Console.WriteLine(BinarySearch(arr, -1000));
            Console.WriteLine(BinarySearch(arr, 0));
            Console.WriteLine(BinarySearch(arr, 17));
            Console.WriteLine(BinarySearch(arr, 10));
            Console.WriteLine(BinarySearch(arr, 1000));
        }

        /// <summary>
        /// Sorts the input array using selection sort.
        /// </summary>
        /// <param name="arr">The input array.</param>
        /// <typeparam name="T">Generic type parameter for array elements.</typeparam>
        public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Input array must not be null!");
            
            if (arr == null)
            {
                throw new ArgumentNullException("arr", "Input array must not be null!");
            }

            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
                Swap(ref arr[index], ref arr[minElementIndex]);
            }

            for (int i = 0; i < arr.Length - 2; i++)
            {
                Debug.Assert(arr[i].CompareTo(arr[i + 1]) <= 0, "Result array must be sorted!");
            }
        }

        /// <summary>
        /// Searches an element within a given array.
        /// </summary>
        /// <remarks>
        /// Uses Binary Search algorithm.
        /// <seealso cref="http://en.wikipedia.org/wiki/Binary_search_algorithm"/>
        /// </remarks>
        /// <param name="arr">The input array.</param>
        /// <param name="value">The searched value.</param>
        /// <typeparam name="T">Generic type parameter for array elements.</typeparam>
        /// <returns>The index of the searched element.</returns>
        public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Input array must not be null!");
            Debug.Assert(value != null, "Searched value must not be null!");

            if (arr == null)
            {
                throw new ArgumentNullException("arr", "Input array must not be null!");
            }

            if (value == null)
            {
                throw new ArgumentNullException("value", "Searched value must not be null!");
            }

            return BinarySearch(arr, value, 0, arr.Length - 1);
        }

        /// <summary>
        /// Finds the index of the min element.
        /// </summary>
        /// <param name="arr">The input array.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="endIndex">The end index.</param>
        /// <typeparam name="T">Generic type parameter for array elements.</typeparam>
        /// <returns>The index of the min element.</returns>
        private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Input array must not be null!");
            Debug.Assert(arr.Length > 0, "Input array must not be empty!");
            Debug.Assert(startIndex >= 0, "Start index must be positive!");
            Debug.Assert(endIndex >= 0, "End index must be positive!");
            Debug.Assert(startIndex <= endIndex, "Start index must be greater or equal to end index!");
            Debug.Assert(startIndex < arr.Length, "Start index must be smaller than input array length:" + arr.Length + "!");
            Debug.Assert(endIndex < arr.Length, "End index must be smaller than input array length:" + arr.Length + "!");

            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            for (int i = startIndex; i < endIndex; i++)
            {
                Debug.Assert(arr[minElementIndex].CompareTo(arr[i]) <= 0, "The returned element is not the min element within the given range!");
            }

            return minElementIndex;
        }

        /// <summary>
        /// Searches an element within an array by given start and end index.
        /// </summary>
        /// <param name="arr">The input array.</param>
        /// <param name="value">The searched value.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="endIndex">The end index.</param>
        /// <typeparam name="T">Generic type parameter for array elements.</typeparam>
        /// <returns>The index of the searched element.</returns>
        private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            for (int i = 0; i < arr.Length - 2; i++)
            {
                Debug.Assert(arr[i].CompareTo(arr[i + 1]) <= 0, "Input array must be sorted!");
            }

            Debug.Assert(arr != null, "Input array must not be null!");
            Debug.Assert(value != null, "Searched value must not be null!");
            Debug.Assert(startIndex >= 0, "Start index must be positive!");
            Debug.Assert(endIndex >= 0, "End index must be positive!");
            Debug.Assert(startIndex <= endIndex, "Start index must be greater or equal to end index!");
            Debug.Assert(startIndex < arr.Length, "Start index must be smaller than input array length:" + arr.Length + "!");
            Debug.Assert(endIndex < arr.Length, "End index must be smaller than input array length:" + arr.Length + "!");

            if (arr.Length == 0)
            {
                return -1;
            }
            
            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;
                if (arr[midIndex].Equals(value))
                {
                    Debug.Assert(arr[midIndex].CompareTo(value) == 0, "The element at position: [" + midIndex + "]=" + arr[midIndex] + " is different from the searched element: " + value + "!");
                    return midIndex;
                }

                if (arr[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the right half
                    endIndex = midIndex - 1;
                }
            }

            // Searched value not found
            return -1;
        }

        /// <summary>
        /// Swaps the specified x with the specified y.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <typeparam name="T">Generic type parameter for x and y.</typeparam>
        private static void Swap<T>(ref T x, ref T y)
        {
            T oldX = x;
            x = y;
            y = oldX;
        }
    }
}