// ********************************
// <copyright file="ServiceClientDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace ServiceDayOfWeek.Client
{
    using System;
    using ServiceDayOfWeek.Client.ServiceDayOfWeekReference;

    /// <summary>
    /// Demonstrates how to consumme wcf service.
    /// </summary>
    public class ServiceClientDemo
    {
        /* 02. Create a console-based client for the WCF service above. 
         * Use the "Add Service Reference" in Visual Studio.*/

        /// <summary>
        /// Mains this instance.
        /// </summary>
        static void Main()
        {
            ServiceDayOfWeekClient client = new ServiceDayOfWeekClient();

            var dayInBg = client.GetDayOfWeek(DateTime.Now);

            Console.WriteLine("Днес е: {0}.", dayInBg);
        }
    }
}
