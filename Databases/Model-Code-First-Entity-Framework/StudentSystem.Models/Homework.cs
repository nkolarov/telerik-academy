// ********************************
// <copyright file="Homework.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace StudentSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Represents a homework.
    /// </summary>
    [Table("Homeworks")]
    public class Homework
    {
        [Key, Column("HomeworkId")]
        public int HomeworkId { get; set; }

        [Column("Content")]
        public string Content { get; set; }

        [Column("TimeSent")]
        public DateTime TimeSent { get; set; }

        [Column("Course"), ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        [Column("Student"), ForeignKey("Student")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
