// ********************************
// <copyright file="FeedzillaDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace ConsumingWebServices
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    /// <summary>
    /// Demonstrates Feedzilla usage.
    /// </summary>
    public class FeedzillaDemo
    {
        /* 01. Write a console application, which searches for news articles by given a query string and a count of articles to retrieve. 
         * The application should ask the user for input and print the Titles and URLs of the articles.
         * For news articles search use the Feedzilla API and use one of WebClient, HttpWebRequest or HttpClient.
         */

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://api.feedzilla.com/");

            Console.WriteLine("Please enter query string (example: Michael): ");
            string queryStr = Console.ReadLine();
            string url = "v1/articles/search.json?q=" + queryStr;

            PrintArticles(client, url);
            Console.ReadLine();
        }

        /// <summary>
        /// Prints all articles by given http client and url.
        /// </summary>
        /// <param name="client">The http client.</param>
        /// <param name="url">The url.</param>
        private static async void PrintArticles(HttpClient client, string url)
        {
            var response = await client.GetAsync(url);
            var articles = await response.Content.ReadAsStringAsync();
            var articlesCollection = JsonConvert.DeserializeObject<ArticlesCollection>(articles);

            // Deserialize and print article data.
            foreach (var article in articlesCollection.Articles)
            {
                var currentArticle = JsonConvert.DeserializeObject<Artcile>(article.ToString());
                Console.WriteLine(new string('-', 50));
                Console.WriteLine("Title: " + currentArticle.Title);
                Console.WriteLine("Url: " + currentArticle.Url);
            }
        }
    }
}
