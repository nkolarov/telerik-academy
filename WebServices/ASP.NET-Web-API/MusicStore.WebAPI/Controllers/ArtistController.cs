// ****************************************************************
// <copyright file="ArtistController.cs" company="Telerik Academy">
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

    public class ArtistController : ApiController
    {
        private IRepository<Artist> dbRepository;

        public ArtistController()
        {
            var dbContext = new MusicStoreContext();
            this.dbRepository = new DbRepository<Artist>(dbContext);
        }

        public ArtistController(IRepository<Artist> repository)
        {
            this.dbRepository = repository;
        }


        // GET api/Artist
        public IEnumerable<ArtistModel> GetArtists()
        {
            var artists = this.dbRepository.All();

            var artistModels =
                from artist in artists
                select new ArtistModel()
                {
                    ArtistId = artist.ArtistId,
                    Name = artist.Name,
                    Country = artist.Country,
                    BirthDate = artist.BirthDate,
                    AlbumsCount = artist.Albums.Count
                };

            return artistModels;
        }

        // GET api/Artist/5
        public ArtistFullModel GetArtist(int id)
        {
            var artist = this.dbRepository.Get(id);
            if (artist == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return new ArtistFullModel()
            {
                ArtistId = artist.ArtistId,
                Name = artist.Name,
                Country = artist.Country,
                BirthDate = artist.BirthDate,
                Albums =
                        from album in artist.Albums
                        select new AlbumModel() {  
                            Title = album.Title, 
                            SongsCount = album.Songs.Count, 
                            AlbumId = album.AlbumId, 
                            ArtistsCount = album.Artists.Count, 
                            Producer = album.Producer, 
                            ReleaseDate = album.ReleaseDate}
            };
        }

        // PUT api/Artist/5
        public HttpResponseMessage PutArtist(int id, Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != artist.ArtistId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                this.dbRepository.Update(id, artist);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Artist
        public HttpResponseMessage PostArtist(Artist artist)
        {
            if (ModelState.IsValid)
            {
                this.dbRepository.Add(artist);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, artist);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = artist.ArtistId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Artist/5
        public HttpResponseMessage DeleteArtist(int id)
        {
            Artist artist = this.dbRepository.Get(id);
            if (artist == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                this.dbRepository.Delete(artist);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, artist);
        }
    }
}