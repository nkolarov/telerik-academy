// ********************************
// <copyright file="Course.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Courses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Represents the abstraction Course.
    /// </summary>
    public abstract class Course
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Course" /> class.
        /// </summary>
        /// <param name="courseName">Name of the course.</param>
        /// <param name="teacherName">Name of the teacher.</param>
        /// <param name="students">The students.</param>
        protected Course(string courseName, string teacherName, IList<string> students)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            if (students == null)
            {
                this.Students = new List<string>();
            }
            else
            {
                this.Students = students;
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets or sets the name of the teacher.
        /// </summary>
        /// <value>The name of the teacher.</value>
        public string TeacherName { get; set; }

        /// <summary>
        /// Gets or sets the students.
        /// </summary>
        /// <value>The students.</value>
        public IList<string> Students { get; set; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("{0} {{ Name = ", this.GetType());
            result.Append(this.Name);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());
            result.Append(" }");
            return result.ToString();
        }

        /// <summary>
        /// Gets the students as string.
        /// </summary>
        /// <returns>The students as string.</returns>
        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}