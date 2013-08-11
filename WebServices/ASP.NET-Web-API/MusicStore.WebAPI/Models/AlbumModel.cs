// ****************************************************************
// <copyright file="AlbumModel.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ****************************************************************

namespace MusicStore.WebAPI.Models
{
    using MusicStore.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class AlbumModel
    {
        public int AlbumId { get; set; }

        public string Title { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string Producer { get; set; }

        public int ArtistsCount { get; set; }

        public int SongsCount { get; set; }
    }

    public class AlbumFullModel : AlbumModel
    {
        public IEnumerable<ArtistModel> Artists { get; set; }
        public IEnumerable<SongModel> Songs { get; set; }
    }
}