// ********************************
// <copyright file="Student.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************
namespace ExceptionsHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///  Represents a Student.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Student" /> class.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="exams">The exams list.</param>
        public Student(string firstName, string lastName, IList<Exam> exams)
        {
            if (firstName == null)
            {
                throw new ArgumentNullException("firstName", "First Name must not be null!");
            }

            if (lastName == null)
            {
                throw new ArgumentNullException("lastName", "Last Name must not be null!");
            }

            if (exams == null)
            {
                throw new ArgumentNullException("exams", "Exams list must not be null!");
            }

            this.FirstName = firstName;
            this.LastName = lastName;
            this.Exams = exams;
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the exams list.
        /// </summary>
        /// <value>The exams.</value>
        public IList<Exam> Exams { get; set; }

        /// <summary>
        /// Gets the exams results.
        /// </summary>
        /// <returns>List with exam results.</returns>
        public IList<ExamResult> GetExamsResults()
        {
            IList<ExamResult> examsResults = new List<ExamResult>();
            for (int i = 0; i < this.Exams.Count; i++)
            {
                examsResults.Add(this.Exams[i].CalculateReesult());
            }

            return examsResults;
        }

        /// <summary>
        /// Calculates the average result in percent.
        /// </summary>
        /// <returns>The average result of exams as percentage.</returns>
        public double CalcAverageResultInPercent()
        {
            int examCount = this.Exams.Count;

            if (examCount == 0)
            {
                return 0;
            }

            double[] examScore = new double[examCount];
            IList<ExamResult> examResults = this.GetExamsResults();

            for (int i = 0; i < examResults.Count; i++)
            {
                examScore[i] = (double)(examResults[i].Grade - examResults[i].MinGrade) /
                               (examResults[i].MaxGrade - examResults[i].MinGrade);
            }

            return examScore.Average();
        }
    }
}