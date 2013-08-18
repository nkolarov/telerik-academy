// ****************************************************************
// <copyright file="CodeJewelsContext.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ****************************************************************

namespace CodeJewels.Data
{
    using CodeJewels.Models;
    using System;
    using System.Data.Entity;

    public class CodeJewelsContext: DbContext
    {
        public CodeJewelsContext() : base("CodeJewels") { }

        public DbSet<Jewel> Jewels { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Vote> Votes { get; set; }
    }
}
