// ********************************
// <copyright file="CoursesExamples.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Courses
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Just an example. Shows Courses usage.
    /// </summary>
    public class CoursesExamples
    {
        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            LocalCourse localCourse = new LocalCourse("Databases");
            Console.WriteLine(localCourse);

            localCourse.Lab = "Enterprise";
            Console.WriteLine(localCourse);

            localCourse.Students = new List<string>() { "Peter", "Maria" };
            Console.WriteLine(localCourse);

            localCourse.TeacherName = "Svetlin Nakov";
            localCourse.Students.Add("Milena");
            localCourse.Students.Add("Todor");
            Console.WriteLine(localCourse);

            OffsiteCourse offsiteCourse = new OffsiteCourse("PHP and WordPress Development", "Mario Peshev", new List<string>() { "Thomas", "Ani", "Steve" });
            Console.WriteLine(offsiteCourse);
        }
    }
}