// ********************************
// <copyright file="ArticlesCollection.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace ConsumingWebServices
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents an articles collection.
    /// </summary>
    public class ArticlesCollection
    {
        public IEnumerable<object> Articles { get; set; }
    }
}
