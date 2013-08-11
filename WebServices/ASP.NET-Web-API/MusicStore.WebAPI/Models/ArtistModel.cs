// ****************************************************************
// <copyright file="ArtistModel.cs" company="Telerik Academy">
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

    public class ArtistModel
    {
        public int ArtistId { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public DateTime? BirthDate { get; set; }

        public int AlbumsCount { get; set; }
    }

    public class ArtistFullModel : ArtistModel
    {
        public virtual IEnumerable<AlbumModel> Albums { get; set; }
    }
}