// ****************************************************************
// <copyright file="SongController.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ****************************************************************

namespace MusicStore.WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web;
    using System.Web.Http;
    using MusicStore.Model;
    using MusicStore.Data;
    using MusicStore.Repositories;
    using MusicStore.WebAPI.Models;

    public class SongController : ApiController
    {
        private IRepository<Song> dbRepository;

        public SongController()
        {
            var dbContext = new MusicStoreContext();
            this.dbRepository = new DbRepository<Song>(dbContext);
        }

        public SongController(IRepository<Song> repository)
        {
            this.dbRepository = repository;
        }

        // GET api/Song
        public IEnumerable<SongModel> GetSongs()
        {
            var songs = this.dbRepository.All();

            var songModels =
                from song in songs
                select new SongModel()
                {
                    SongId = song.SongId,
                    Title = song.Title,
                    Genre = song.Genre,
                    Year = song.Year,
                };

            return songModels;
        }

        // GET api/Song/5
        public SongFullModel GetSong(int id)
        {
            var song = this.dbRepository.Get(id);
            if (song == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            ArtistModel artist = null;

            if (song.Artist != null)
            {
                artist = new ArtistModel() { ArtistId = song.Artist.ArtistId, Name = song.Artist.Name, Country = song.Artist.Country, BirthDate = song.Artist.BirthDate, AlbumsCount = song.Artist.Albums.Count };
            }

            return new SongFullModel()
            {
                SongId = song.SongId,
                Title = song.Title,
                Genre = song.Genre,
                Year = song.Year,
                Artist = artist
            };
        }

        // PUT api/Song/5
        public HttpResponseMessage PutSong(int id, Song song)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != song.SongId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                this.dbRepository.Update(id, song);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Song
        public HttpResponseMessage PostSong(Song song)
        {
            if (ModelState.IsValid)
            {
                this.dbRepository.Add(song);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, song);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = song.SongId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Song/5
        public HttpResponseMessage DeleteSong(int id)
        {
            Song song = this.dbRepository.Get(id);
            if (song == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                this.dbRepository.Delete(song);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, song);
        }

    }
}