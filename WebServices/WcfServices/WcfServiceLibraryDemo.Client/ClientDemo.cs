// ********************************
// <copyright file="ClientDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace WcfServiceLibraryDemo.Client
{
    using System;
    using System.ServiceModel;

    /// <summary>
    /// Demonstrates how to generate proxy with svc util and connect to service.
    /// </summary>
    public class ClientDemo
    {
        /* 05. Create a console client for the WCF service above. Use the svcutil.exe tool to generate the proxy classes.*/

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
