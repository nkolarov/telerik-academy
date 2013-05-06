// ********************************
// <copyright file="LocalCourse.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Courses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Represents Local Course.
    /// </summary>
    public class LocalCourse : Course
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocalCourse" /> class.
        /// </summary>
        /// <param name="courseName">Name of the course.</param>
        /// <param name="teacherName">Name of the teacher.</param>
        /// <param name="students">The students.</param>
        /// <param name="lab">The lab.</param>
        public LocalCourse(string courseName, string teacherName = null, IList<string> students = null, string lab = null) : base(courseName, teacherName, students)
        {
            this.Lab = lab;
        }

        /// <summary>
        /// Gets or sets the lab.
        /// </summary>
        /// <value>The lab.</value>
        public string Lab { get; set; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            // Removes last closing bracket from base class.                
            if (result[result.Length] == '}')
            {
                result.Length--;
            }
            
            if (this.Lab != null)
            {
                result.Append("; Lab = ");
                result.Append(this.Lab);
            }

            result.Append(" }");
            return result.ToString();
        }
    }
}