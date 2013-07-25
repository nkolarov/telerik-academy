// ********************************
// <copyright file="ExtractAllSongTitlesXDocument.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace ExtractAllSongTitlesXDocument
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// Demonstrates how to parse XML document using XDocument.
    /// </summary>
    public class ExtractAllSongTitlesXDocument
    {
        /* 05. Write a program, which using XmlReader extracts all song titles from catalog.xml.*/
        public static void Main()
        {
            XDocument xmlDoc = XDocument.Load("..\\..\\..\\catalog.xml");

            var songTitles =
                    from song in xmlDoc.Descendants("song")
                    select song.Element("title").Value;
            // Print result
            foreach (var songTitle in songTitles)
            {
                Console.WriteLine(songTitle);
            }
        }
    }
}
