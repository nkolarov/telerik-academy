// ****************************************************************
// <copyright file="Artist.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ****************************************************************

namespace MusicStore.Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents an artist.
    /// </summary>
    public class Artist
    {
        public int ArtistId { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public DateTime? BirthDate { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
