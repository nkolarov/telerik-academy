// ********************************
// <copyright file="ExamResult.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************
namespace ExceptionsHomework
{
    using System;

    /// <summary>
    ///  Represents an Exam Result for Student.
    /// </summary>
    public class ExamResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExamResult" /> class.
        /// </summary>
        /// <param name="grade">The grade.</param>
        /// <param name="minGrade">The min grade.</param>
        /// <param name="maxGrade">The max grade.</param>
        /// <param name="comments">The comments.</param>
        public ExamResult(int grade, int minGrade, int maxGrade, string comments)
        {
            if (grade < 0)
            {
                throw new ArgumentOutOfRangeException("grade", "Grade must be positive!");
            }

            if (minGrade < 0)
            {
                throw new ArgumentOutOfRangeException("minGrade", "MinGrade must be positive!");
            }

            if (maxGrade <= minGrade)
            {
                throw new ArgumentOutOfRangeException("maxGrade", "MinGrade must be less than MaxGrade!");
            }

            if (string.IsNullOrWhiteSpace(comments))
            {
                throw new ArgumentException("Comments must not be null!", "comments");
            }

            this.Grade = grade;
            this.MinGrade = minGrade;
            this.MaxGrade = maxGrade;
            this.Comments = comments;
        }

        /// <summary>
        /// Gets the grade.
        /// </summary>
        /// <value>The grade.</value>
        public int Grade { get; private set; }

        /// <summary>
        /// Gets the min grade.
        /// </summary>
        /// <value>The min grade.</value>
        public int MinGrade { get; private set; }

        /// <summary>
        /// Gets the max grade.
        /// </summary>
        /// <value>The max grade.</value>
        public int MaxGrade { get; private set; }

        /// <summary>
        /// Gets the comments.
        /// </summary>
        /// <value>The comments.</value>
        public string Comments { get; private set; }
    }
}