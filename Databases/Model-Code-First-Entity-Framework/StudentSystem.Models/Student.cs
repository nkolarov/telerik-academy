// ********************************
// <copyright file="Student.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace StudentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Represents a student.
    /// </summary>
    [Table("Students")]
    public class Student
    {
        /* 01. Using c0de first approach, create database for student system with the following tables:
            Students (with Id, Name, Number, etc.)
            Courses (Name, Description, Materials, etc.)
            StudentsInCourses (many-to-many relationship)
            Homework (one-to-many relationship with students and courses), fields: Content, TimeSent
            Annotate the data models with the appropriate attributes and enable code first migrations
            */

        private ICollection<Course> courses;
        private ICollection<Homework> homeworks;

        [Key, Column("StudentId")]
        public int StudentID { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Number")]
        public int Number { get; set; }


        public Student()
        {
            this.courses = new HashSet<Course>();
            this.homeworks = new HashSet<Homework>();
        }

        public virtual ICollection<Course> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; }
        }

    }

}
