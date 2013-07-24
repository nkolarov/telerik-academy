// ********************************
// <copyright file="StudentSystemDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace StudentSystem.Client
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using StudentSystem.Data;
    using StudentSystem.Data.Migrations;
    using StudentSystem.Models;

    /// <summary>
    /// Demostrates Student system data using.
    /// </summary>
    public class StudentSystemDemo
    {
        /* 02. Write a console application that uses the data.*/
        /// <summary>
        /// Mains this instanse.
        /// </summary>
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());
            using (var db = new StudentSystemContext())
            {
                var pesho = new Student { Name = "Pesho", Number = 666 };
                db.Students.Add(pesho);
                db.SaveChanges();

                var dbCourse = new Course
                {
                    Name = "Database Course",
                    Description = "Basic Database operations",
                    Materials = "http://telerikacademy.com/Courses/Courses/Details/98"
                };
                db.Courses.Add(dbCourse);
                db.SaveChanges();

                var course = db.Courses.First(c => c.Name == dbCourse.Name);
                var student = db.Students.First(s => s.Number == pesho.Number);

                var hw = new Homework
                {
                    Content = "Empty Homework",
                    TimeSent = DateTime.Now,
                    CourseId = course.CourseId,
                    StudentId = student.StudentID
                };
                db.Homeworks.Add(hw);
                db.SaveChanges();
            }

            ListStudents();
        }

        /// <summary>
        /// List all students.
        /// </summary>
        private static void ListStudents()
        {
            using (var db = new StudentSystemContext())
            {
                var students = db.Students;

                foreach (var student in students)
                {
                    Console.WriteLine("Name: {0}, Number: {1}", student.Name, student.Number);
                }
            }
        }
    }
}
