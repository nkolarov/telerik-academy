// ****************************************************************
// <copyright file="Song.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ****************************************************************

namespace MusicStore.Model
{
    using System;

    /// <summary>
    /// Represents a song.
    /// </summary>
    public class Song
    {
        public int SongId { get; set; }

        public string Title { get; set; }

        public DateTime? Year { get; set; }

        public string Genre { get; set; }

        public Artist Artist { get; set; }
    }
}
