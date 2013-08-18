// ****************************************************************
// <copyright file="UploadImagesDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ****************************************************************

namespace UploadImages
{
    using DropNet;
    using DropNet.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Demonstrates how to upload folder to dropbox.
    /// </summary>
    public class UploadImagesDemo
    {
        /* 03. Write a C# program to publish a photo album with few photos into DropBox and share the photos through the Dropbox sharing functionality.*/

        private static string ALBUM_NAME = "SampleAlbum";
        private static string ALBUM_FOLDER = "..\\..\\images";
        private static string IMAGES_EXTENSION = "*.jpg";
        private static string APP_KEY = "";
        private static string APP_SECRET = "";

        /// <summary>
        /// Mains this instance.
        /// </summary>
        static void Main()
        {
            // Login
            Console.WriteLine("You must add you dropbox keys in the config!");
            Console.WriteLine("You must first login in your dropbox account.");
            DropNetClient client = DropBoxLogIn();

            Console.WriteLine("Starting upload...");

            var shareUrl = UploadAlbum(client);
            Console.WriteLine(shareUrl.Url);
        }

        /// <summary>
        /// Uploads an album in dropbox client. 
        /// </summary>
        /// <param name="client">The dropbox client.</param>
        /// <returns></returns>
        private static ShareResponse UploadAlbum(DropNetClient client)
        {
            var folder = client.CreateFolder(ALBUM_NAME);
            DirectoryInfo info = new DirectoryInfo(ALBUM_FOLDER);
            FileInfo[] images = info.GetFiles(IMAGES_EXTENSION);

            UploadImages(client, folder, images);

            var shareUrl = client.GetShare(folder.Path);
            return shareUrl;
        }

        /// <summary>
        /// Uploads images in dropbox album.
        /// </summary>
        /// <param name="client">The dropbox client.</param>
        /// <param name="folder">The dropbox folder.</param>
        /// <param name="images">The images.</param>
        private static void UploadImages(DropNetClient client, MetaData folder, FileInfo[] images)
        {
            foreach (var image in images)
            {
                MemoryStream sr = new MemoryStream((int)image.Length);
                FileStream fs = File.Open(image.FullName, FileMode.Open);

                var bytes = new byte[fs.Length];

                fs.Read(bytes, 0, Convert.ToInt32(fs.Length));

                client.UploadFile(folder.Path, image.Name, bytes);

                fs.Close();
            }
        }

        /// <summary>
        /// Logs in to dropbox.
        /// </summary>
        /// <returns>Drop box client object.</returns>
        private static DropNetClient DropBoxLogIn()
        {
            DropNetClient client = new DropNetClient(APP_KEY, APP_SECRET);
            var token = client.GetToken();
            var url = client.BuildAuthorizeUrl();

            Console.WriteLine("Copy paste the link in your browser. Press any key when done.");
            Console.WriteLine(url);
            Console.ReadKey();

            var accessToken = client.GetAccessToken();

            client.UserLogin.Secret = accessToken.Secret;
            client.UserLogin.Token = accessToken.Token;
            client.UseSandbox = true;
            return client;
        }
    }
}

