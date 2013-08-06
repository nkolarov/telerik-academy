// ****************************************************************
// <copyright file="MusicStoreContext.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ****************************************************************

namespace MusicStore.Data
{
    using System;
    using System.Data.Entity;
    using MusicStore.Model;

    /// <summary>
    /// Represents a music store context.
    /// </summary>
    public class MusicStoreContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MusicStoreContext"/> class.
        /// </summary>
        public MusicStoreContext()
            : base("MusicStoreDB")
        {
        }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Song> Songs { get; set; }
    }
}
