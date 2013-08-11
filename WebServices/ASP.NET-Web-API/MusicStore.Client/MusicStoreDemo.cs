// ****************************************************************
// <copyright file="MusicStoreConsumeDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ****************************************************************

namespace MusicStore.Client
{
    using MusicStore.Model;
    using MusicStore.WebAPI.Models;
    using System;
    using System.Collections.Generic;

    public class MusicStoreDemo
    {
        static void Main()
        {
            var baseUrl = "http://localhost:12243/";
            var contentType = "application/json";
            var requester = new HttpRequester(baseUrl, contentType);

            // Test album Creation
            Album album = new Album { Producer = "Pesho", Title = "Testov album", ReleaseDate = DateTime.Now };
            requester.Post<Album>("api/album", album);
            Console.WriteLine("Simple Album added!");

            Song song = new Song { Genre = "RnB", Title = "Shake it!", Year = DateTime.Now.AddYears(-20) };
            Artist artist = new Artist { Name = "Pesho Zlia", BirthDate = new DateTime(1950, 1, 1), Country = "Germany" };
            album.Songs.Add(song);
            album.Artists.Add(artist);

            requester.Post<Album>("api/album", album);
            Console.WriteLine("Album added!");

            // Test albums Retrieving
            var retrievedAlbums = requester.Get<IList<Album>>("api/album/");
            foreach (var retrievedAlbum in retrievedAlbums)
            {
                Console.WriteLine("Album found! Title:" + retrievedAlbum.Title);
            }

            // Test one album Retrieving
            var getedAlbum = requester.Get<Album>("api/album/" + retrievedAlbums[0].AlbumId);

            Console.WriteLine("First Album found! Title:" + getedAlbum.Title);

            // Test album updating

            getedAlbum.Title = "Updated Title";
            requester.Put<Album>("api/album/" + getedAlbum.AlbumId, getedAlbum);
            Console.WriteLine("Title updated!");

            // Check new title
            getedAlbum = requester.Get<Album>("api/album/" + retrievedAlbums[0].AlbumId);
            Console.WriteLine("First Album found! Title:" + getedAlbum.Title);

            // Add 
            Album newAlbum = new Album { Producer = "Pesho", Title = "Testov album", ReleaseDate = DateTime.Now };

            //Delete the album!
            requester.Delete<Album>("api/album/" + getedAlbum.AlbumId, getedAlbum);
            Console.WriteLine("Album deleted");

        }
    }
}
