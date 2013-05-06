// ********************************
// <copyright file="OffsiteCourse.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Courses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Represents Offsite Course.
    /// </summary>
    public class OffsiteCourse : Course
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OffsiteCourse" /> class.
        /// </summary>
        /// <param name="courseName">Name of the course.</param>
        /// <param name="teacherName">Name of the teacher.</param>
        /// <param name="students">The students.</param>
        /// <param name="town">The town.</param>
        public OffsiteCourse(string courseName, string teacherName, IList<string> students = null, string town = null) : base(courseName, teacherName, students)
        {
            this.Town = town;
        }

        /// <summary>
        /// Gets or sets the town.
        /// </summary>
        /// <value>The town.</value>
        public string Town { get; set; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());

            // Removes last closing bracket from base class.                
            if (result[result.Length-1] == '}')
            {
                result.Length--; 
            }

            if (this.Town != null)
            {
                result.Append("; Town = ");
                result.Append(this.Town);
            }

            result.Append(" }");
            return result.ToString();
        }
    }
}