// ****************************************************************
// <copyright file="AlbumController.cs" company="Telerik Academy">
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
    using MusicStore.WebAPI.Models;
    using MusicStore.Repositories;

    public class AlbumController : ApiController
    {
        private IRepository<Album> dbRepository;

        public AlbumController()
        {
            var dbContext = new MusicStoreContext();
            this.dbRepository = new DbRepository<Album>(dbContext);
        }

        public AlbumController(IRepository<Album> repository)
        {
            this.dbRepository = repository;
        }

        // GET api/Album
        public IEnumerable<AlbumModel> GetAlbums()
        {
            var albums = this.dbRepository.All();

            var albumModels =
                from album in albums
                select new AlbumModel()
                {
                    AlbumId = album.AlbumId,
                    Title = album.Title,
                    Producer = album.Producer,
                    ReleaseDate = album.ReleaseDate,
                    SongsCount = album.Songs.Count,
                    ArtistsCount = album.Artists.Count
                };

            return albumModels;
        }

        // GET api/Album/5
        public AlbumFullModel GetAlbum(int id)
        {
            var album = this.dbRepository.Get(id);
            if (album == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return new AlbumFullModel()
            {
                AlbumId = album.AlbumId,
                Title = album.Title,
                Producer = album.Producer,
                ReleaseDate = album.ReleaseDate,
                Songs =
                        from song in album.Songs
                        select new SongModel() { SongId = song.SongId, Title = song.Title, Genre = song.Genre, Year = song.Year },
                Artists =
                        from artist in album.Artists
                        select new ArtistModel() { ArtistId = artist.ArtistId, Name = artist.Name, Country = artist.Country, BirthDate = artist.BirthDate, AlbumsCount = artist.Albums.Count }
            };
        }

        // PUT api/Album/5
        public HttpResponseMessage PutAlbum(int id, Album album)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != album.AlbumId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                this.dbRepository.Update(id, album);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Album
        public HttpResponseMessage PostAlbum(Album album)
        {
            if (ModelState.IsValid)
            {
                this.dbRepository.Add(album);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, album);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = album.AlbumId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Album/5
        public HttpResponseMessage DeleteAlbum(int id)
        {
            Album album = this.dbRepository.Get(id);
            if (album == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                this.dbRepository.Delete(album);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, album);
        }
    }
}
