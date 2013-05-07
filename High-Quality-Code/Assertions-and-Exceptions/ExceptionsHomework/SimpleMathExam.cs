// ********************************
// <copyright file="SimpleMathExam.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************
namespace ExceptionsHomework
{
    using System;

    /// <summary>
    ///  Represents a simple math exam.
    /// </summary>
    public class SimpleMathExam : Exam
    {
        /// <summary>
        /// Max problem counter.
        /// </summary>
        public const int ProblemCounter = 2;

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleMathExam" /> class.
        /// </summary>
        /// <param name="problemsSolved">The number of problems solved.</param>
        public SimpleMathExam(int problemsSolved)
        {
            if (problemsSolved < 0)
            {
                throw new ArgumentOutOfRangeException("problemSolved", "Poblem solved must be positive!");
            }

            if (problemsSolved > ProblemCounter)
            {
                throw new ArgumentOutOfRangeException("problemSolved", "Poblem solved must be less than maximum problem counter: " + ProblemCounter + "!");
            }

            this.ProblemsSolved = problemsSolved;
        }

        /// <summary>
        /// Gets the number of the solved problems.
        /// </summary>
        /// <value>The problems solved.</value>
        public int ProblemsSolved { get; private set; }

        /// <summary>
        /// Calculates the exam result.
        /// </summary>
        /// <returns>The result.</returns>
        public override ExamResult CalculateReesult()
        {
            switch (this.ProblemsSolved)
            {
                case 0:
                    return new ExamResult(2, 2, 6, "Bad result: nothing done.");
                case 1:
                    return new ExamResult(4, 2, 6, "Good result: 1 problem solved.");
                default:
                    return new ExamResult(6, 2, 6, "Excelent result: 2 problems solved.");
            }
        }
    }
}