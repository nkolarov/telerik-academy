// ********************************
// <copyright file="ServiceDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace WcfServiceDayOfWeek
{
    using System;
    using System.Globalization;
    using System.Threading;

    /// <summary>
    /// Demonstrates wcf services usage.
    /// </summary>
    public class ServiceDemo : IServiceDayOfWeek
    {
        /*01. Create a simple WCF service. It should have a method that accepts a DateTime parameter and returns the day of week (in Bulgarian) as string. 
         * Test it with the integrated WCF client.*/

        /// <summary>
        /// Gets the day of week by given date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The day of week in bulgarian.</returns>
        public string GetDayOfWeek(DateTime date)
        {
            var cultureInfo = new CultureInfo("bg-BG");
            var dayNum = (int)date.DayOfWeek;
            var dayOfWeekInBg = cultureInfo.DateTimeFormat.DayNames[dayNum];

            return dayOfWeekInBg;
        }
    }
}
