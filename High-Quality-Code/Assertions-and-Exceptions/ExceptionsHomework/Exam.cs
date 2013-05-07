// ********************************
// <copyright file="Exam.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************
namespace ExceptionsHomework
{
    using System;

    /// <summary>
    ///  Calculates the result from an Exam.
    /// </summary>
    public abstract class Exam
    {
        /// <summary>
        /// Calculates the exam result.
        /// </summary>
        /// <returns>The result.</returns>
        public abstract ExamResult CalculateReesult();
    }
}