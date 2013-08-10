// ********************************
// <copyright file="IServiceDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace WcfServiceLibraryDemo
{
    using System;
    using System.Runtime.Serialization;
    using System.ServiceModel;

    /// <summary>
    /// Describes service contracts.
    /// </summary>
    [ServiceContract]
    public interface IServiceDemo
    {
        /// <summary>
        /// Gets the number of times the second string contains the first string.
        /// </summary>
        /// <param name="firstString">The first string.</param>
        /// <param name="secondString">The second string.</param>
        /// <returns>The count.</returns>
        [OperationContract]
        int GetCount(string firstString, string secondString);
    }
}
