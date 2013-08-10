// ********************************
// <copyright file="ServiceDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace WcfServiceLibraryDemo
{
    using System;
    
    /// <summary>
    /// Demonstrates wcf service library usage.
    /// </summary>
    public class ServiceDemo : IServiceDemo
    {
        /* 03. Create a Web service library which accepts two string as parameters. 
         * It should return the number of times the second string contains the first string. 
         * Test it with the integrated WCF client.*/

        /// <summary>
        /// Gets the number of times the second string contains the first string.
        /// </summary>
        /// <param name="firstString">The first string.</param>
        /// <param name="secondString">The second string.</param>
        /// <returns>The count.</returns>
        public int GetCount(string firstString, string secondString)
        {
            int count = 0;
            int startIndex = 0;

            startIndex = secondString.IndexOf(firstString);

            if (startIndex == -1)
            {
                return 0;
            }

            while (startIndex != -1)
            {
                count++;
                startIndex = secondString.IndexOf(firstString, startIndex + 1);
            }

            return count;
        }
    }
}
