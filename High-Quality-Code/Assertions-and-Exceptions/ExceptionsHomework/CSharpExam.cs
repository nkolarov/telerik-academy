// ********************************
// <copyright file="CSharpExam.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace ExceptionsHomework
{
    using System;

    /// <summary>
    ///  Represents a CSharp Exam.
    /// </summary>
    public class CSharpExam : Exam
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CSharpExam" /> class.
        /// </summary>
        /// <param name="score">The score.</param>
        /// <param name="minGrade">The min grade.</param>
        /// <param name="maxGrade">The max grade.</param>
        public CSharpExam(int score, int minGrade, int maxGrade)
        {
            if (maxGrade < 0)
            {
                throw new ArgumentOutOfRangeException("maxGrade", "Score must be positive!");
            }

            if (minGrade < 0)
            {
                throw new ArgumentOutOfRangeException("minGrade", "Score must be positive!");
            }

            if (score > maxGrade || score < minGrade)
            {
                throw new ArgumentOutOfRangeException("score", "Score must be greater than " + minGrade + " and less than " + maxGrade + "!");
            }

            this.MinGrade = minGrade;
            this.MaxGrade = maxGrade;
            this.Score = score;
        }

        /// <summary>
        /// Gets the max grade.
        /// </summary>
        /// <value>The max grade.</value>
        public int MaxGrade { get; private set; }

        /// <summary>
        /// Gets the min grade.
        /// </summary>
        /// <value>The min grade.</value>
        public int MinGrade { get; private set; }

        /// <summary>
        /// Gets the score.
        /// </summary>
        /// <value>The score.</value>
        public int Score { get; private set; }

        /// <summary>
        /// Calculates the exam result.
        /// </summary>
        /// <returns>The result.</returns>
        public override ExamResult CalculateReesult()
        {
            ExamResult result = new ExamResult(this.Score, this.MinGrade, this.MaxGrade, "Exam results calculated by score.");
            return result;
        }
    }
}