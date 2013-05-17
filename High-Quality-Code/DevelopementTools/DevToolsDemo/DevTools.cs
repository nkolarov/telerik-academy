// ********************************
// <copyright file="DevTools.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace DevToolsDemo
{
    using System;
    using log4net;
    using log4net.Config;

    /// <summary>
    /// Demonstrates log4net basic usage.
    /// </summary>
    public class DevTools
    {
        /// <summary>
        /// Stores log instance.
        /// </summary>  
        private static readonly ILog LOG = LogManager.GetLogger("HelloLog4Net");

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            BasicConfigurator.Configure();
            try
            {
                LOG.Debug("Try to do bad things.");
                int.Parse("Pesho");
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message);
            }
        }
    }
}