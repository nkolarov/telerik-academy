using MusicStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.WebAPI.Models
{
    public class SongModel
    {
        public int SongId { get; set; }

        public string Title { get; set; }

        public DateTime? Year { get; set; }

        public string Genre { get; set; }
    }

    public class SongFullModel : SongModel
    {
        public virtual ArtistModel Artist { get; set; }
    }
}