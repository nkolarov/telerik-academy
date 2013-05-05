// ********************************
// <copyright file="Student.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Utilities
{
    using System;

    /// <summary>
    /// Represents a Student.
    /// </summary>
    internal class Student
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="Student"/> class.
        /// </summary>
        /// <param name="firstName">First Name</param>
        /// <param name="lastName">Last Name</param>
        /// <param name="hometown">Town of birth</param>
        /// <param name="birthday">Day of birth</param>
        /// <param name="additionalInfo">Additional Info</param>
        public Student(string firstName, string lastName, string hometown, DateTime birthday, string additionalInfo = null)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Hometown = hometown;
            this.Birthday = birthday;
            this.AdditionalInfo = additionalInfo;
        }

        /// <summary>
        /// Gets or Sets student`s First Name.
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// Gets or Sets student`s Last Name.
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// Gets or Sets student`s Hometown.
        /// </summary>
        public string Hometown { get; private set; }

        /// <summary>
        /// Gets or Sets student`s Birthday.
        /// </summary>
        public DateTime Birthday { get; private set; }

        /// <summary>
        /// Gets or Sets student`s AdditionalInfo.
        /// </summary>
        public string AdditionalInfo { get; private set; }

        /// <summary>
        /// Checks if Birthday of this Student instance is greater than another Student instance.
        /// </summary>
        /// <param name="student">Second Student instance.</param>
        /// <returns>True if this.Birthday is greater.</returns>
        public bool IsOlderThan(Student student)
        {
            return this.Birthday < student.Birthday;
        }
    }
}