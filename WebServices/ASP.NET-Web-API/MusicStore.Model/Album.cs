// ****************************************************************
// <copyright file="Album.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ****************************************************************

namespace MusicStore.Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents an album.
    /// </summary>
    public class Album
    {
        /// <summary>
        /// Initializes a new <see cref="Album"/> object.
        /// </summary>
        public Album()
        {
            this.Artists = new HashSet<Artist>();
            this.Songs = new HashSet<Song>();
        }

        public int AlbumId { get; set; }

        public string Title { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string Producer { get; set; }

        public virtual ICollection<Artist> Artists { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}
