// ********************************
// <copyright file="ExtractAllArtistsXPath.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace ExtractAllArtistsXPath
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.XPath;

    /// <summary>
    /// Demonstrates how to parse XML document using XPath
    /// </summary>
    public class ExtractAllArtistsXPath
    {
        /* 03. Write program that extracts all different artists which are found in the catalog.xml. 
         * For each author you should print the number of albums in the catalogue. Use the XPath and a hash-table.*/
        public static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("..\\..\\..\\catalog.xml");
            string xPathQuery = "/catalog/album/artist";
            Dictionary<string, int> authorsAblums = new Dictionary<string, int>();

            XmlNodeList authorsList = doc.SelectNodes(xPathQuery);

            foreach (XmlNode node in authorsList)
            {
                var currentArtist = node.InnerText;
                AddToDictionary(authorsAblums, currentArtist);
            }

            ListAuthors(authorsAblums);
        }

        /// <summary>
        /// Lists all authors and the count of their albums.
        /// </summary>
        /// <param name="authorsAblums">The dictionary.</param>
        private static void ListAuthors(Dictionary<string, int> authorsAblums)
        {
            foreach (var artist in authorsAblums)
            {
                Console.WriteLine("{0} -> {1} {2}.", artist.Key, artist.Value, artist.Value == 1 ? "album" : "albums");
            }
        }

        /// <summary>
        /// Adds an artists to the dictionary.
        /// </summary>
        /// <param name="authorsAblums"> The dictionary.</param>
        /// <param name="currentArtist"> The artist.</param>
        private static void AddToDictionary(Dictionary<string, int> authorsAblums, string currentArtist)
        {
            if (authorsAblums.ContainsKey(currentArtist))
            {
                authorsAblums[currentArtist]++;
            }
            else
            {
                authorsAblums[currentArtist] = 1;
            }
        }
    }
}
