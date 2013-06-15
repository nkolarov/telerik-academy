// ********************************
// <copyright file="PriorityQueueDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace PriorityQueueImplementation
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Demonstrates priority queue usage.
    /// </summary>
    public class PriorityQueueDemo
    {
        /*01. Implement a class PriorityQueue<T> based on the data structure "binary heap".*/

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            PriorityQueue<Person> people = new PriorityQueue<Person>();
            people.Enqueue(new Person("George", 21));
            people.Enqueue(new Person("Little Lucho", 2));
            people.Enqueue(new Person("Little Lucho", 2));
            people.Enqueue(new Person("George", 21));
            people.Enqueue(new Person("George", 21));
            people.Enqueue(new Person("Doncho", 23));
            people.Enqueue(new Person("Doncho", 23));
            people.Enqueue(new Person("Doncho", 23));
            people.Enqueue(new Person("Doncho", 23));
            people.Enqueue(new Person("Doncho", 23));
            people.Enqueue(new Person("Niki", 22));
            people.Enqueue(new Person("Nakov", 28));
            people.Enqueue(new Person("Ina", 24));
            people.Enqueue(new Person("Asya", 22));
            people.Enqueue(new Person("George", 21));
            people.Enqueue(new Person("Little Lucho", 2));
            people.Enqueue(new Person("Doncho", 23));
            people.Enqueue(new Person("Niki", 22));
            people.Enqueue(new Person("Nakov", 28));
            people.Enqueue(new Person("Ina", 24));
            people.Enqueue(new Person("Asya", 22));
            people.Enqueue(new Person("George", 21));
            people.Enqueue(new Person("Little Lucho", 2));
            people.Enqueue(new Person("Doncho", 23));
            people.Enqueue(new Person("Niki", 22));
            people.Enqueue(new Person("Nakov", 28));
            people.Enqueue(new Person("Ina", 24));
            people.Enqueue(new Person("Asya", 22));
            people.Enqueue(new Person("George", 21));
            people.Enqueue(new Person("Little Lucho", 2));
            people.Enqueue(new Person("Doncho", 23));
            people.Enqueue(new Person("Niki", 22));
            people.Enqueue(new Person("Nakov", 28));
            people.Enqueue(new Person("Ina", 24));
            people.Enqueue(new Person("Asya", 22));
            people.Enqueue(new Person("George", 21));
            people.Enqueue(new Person("Little Lucho", 2));
            people.Enqueue(new Person("Doncho", 23));
            people.Enqueue(new Person("Niki", 22));
            people.Enqueue(new Person("Nakov", 28));
            people.Enqueue(new Person("Ina", 24));
            people.Enqueue(new Person("Asya", 22));
            people.Enqueue(new Person("George", 21));
            people.Enqueue(new Person("Little Lucho", 2));
            people.Enqueue(new Person("Doncho", 23));
            people.Enqueue(new Person("Niki", 22));
            people.Enqueue(new Person("Nakov", 28));
            people.Enqueue(new Person("Ina", 24));
            people.Enqueue(new Person("Asya", 22));
            while (people.Count > 0)
            {
                Console.WriteLine(people.Dequeue());
            }
        }
    }
}