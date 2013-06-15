// ********************************
// <copyright file="Person.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace PriorityQueueImplementation
{
    using System;

    /// <summary>
    /// Represents a Person.
    /// </summary>
    public class Person : IComparable<Person>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Person" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="age">The age.</param>
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the age.
        /// </summary>
        /// <value>The age.</value>
        public int Age { get; private set; }

        /// <summary>
        /// Compares this instance to a specified other Person and returns
        /// an indication of their relative values.
        /// </summary>
        /// <param name="other">The other Person.</param>
        /// <returns>
        /// A signed number indicating the relative values of this instance and
        /// <paramref name="other" />.Return Value Description Less than zero This instance
        /// is less than <paramref name="other" />. Zero This instance is equal to <paramref name="other" />.
        /// Greater than zero This instance is greater than <paramref name="other" />.
        /// </returns>
        public int CompareTo(Person other)
        {
            return this.Age.CompareTo(other.Age);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return string.Format("{0}, {1}", this.Name, this.Age);
        }
    }
}