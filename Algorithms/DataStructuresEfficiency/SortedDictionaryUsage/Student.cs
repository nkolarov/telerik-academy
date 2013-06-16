// ********************************
// <copyright file="Student.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace SortedDictionaryUsage
{
    using System;

    /// <summary>
    /// Represents a student.
    /// </summary>
    public class Student : IComparable<Student>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Student" /> class.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        /// <summary>
        /// Gets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName { get; private set; }

        /// <summary>
        /// Gets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName { get; private set; }

        /// <summary>
        /// Compares this instance to a specified other Student and returns
        /// an indication of their relative values.
        /// </summary>
        /// <param name="other">The other Student.</param>
        /// <returns>
        /// A signed number indicating the relative values of this instance and
        /// <paramref name="other" />.Return Value Description Less than zero This instance
        /// is less than <paramref name="other" />. Zero This instance is equal to <paramref name="other" />.
        /// Greater than zero This instance is greater than <paramref name="other" />.
        /// </returns>
        public int CompareTo(Student other)
        {
            if (this.FirstName != other.FirstName)
            {
                return this.FirstName.CompareTo(other.FirstName);
            }
            else
            {
                return this.LastName.CompareTo(other.LastName);
            }
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}