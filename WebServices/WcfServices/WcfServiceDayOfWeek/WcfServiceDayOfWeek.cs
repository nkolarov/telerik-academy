// ********************************
// <copyright file="IServiceDayOfWeek.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace WcfServiceDayOfWeek
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Web;

    /// <summary>
    /// Describes day of week service.
    /// </summary>
    [ServiceContract]
    public interface IServiceDayOfWeek
    {
        /// <summary>
        /// Gets the day of week by given date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The day of week in bulgarian.</returns>
        [OperationContract]
        string GetDayOfWeek(DateTime date);
    }
}
