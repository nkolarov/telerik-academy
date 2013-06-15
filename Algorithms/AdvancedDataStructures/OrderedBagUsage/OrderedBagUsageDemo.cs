// ********************************
// <copyright file="OrderedBagUsageDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace OrderedBagUsage
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Wintellect.PowerCollections;

    /// <summary>
    /// Demonstrates ordered bag usage.
    /// </summary>
    public class OrderedBagUsageDemo
    {
        /* 02. Write a program to read a large collection of products (name + price) and efficiently find the first 20 products in the price range [a…b]. 
        Test for 500 000 products and 10 000 price searches.
        Hint: you may use OrderedBag<T> and sub-ranges.
        */

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            OrderedBag<Product> products = new OrderedBag<Product>();
            Random random = new Random();

            // Test creation and filling.
            Stopwatch watch = new Stopwatch();
            watch.Start();

            for (int i = 0; i < 500000; i++)
            {
                products.Add(new Product("Product " + i, random.Next(100, 1000)));
            }

            watch.Stop();
            Console.WriteLine("The creation of 500 000 products takes: {0}", watch.Elapsed);
            watch.Reset();

            // Test searching.
            List<Product> twentyElementsInRange = new List<Product>();

            watch.Restart();
            for (int i = 0; i < 10000; i++)
            {
                Product minSumProduct = new Product("Bulshit", random.Next(100, 500));
                Product maxSumProduct = new Product("CoolStuff", random.Next(500, 1000));
                twentyElementsInRange.AddRange(products.Range(minSumProduct, true, maxSumProduct, true).Take(20));
            }

            watch.Stop();
            Console.WriteLine("10 000 price searches takes: {0}", watch.Elapsed);
        }
    }
}