// ********************************
// <copyright file="FindAlbumsWithLINQ.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace FindAlbumsWithLINQ
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// Demonstrates how to search in XML with LINQ.
    /// </summary>
    public class FindAlbumsWithLINQ
    {
        /* 12. Write a program, which extract from the file catalog.xml the prices for all albums, published 5 years ago or earlier. Use LINQ query.*/
        static void Main(string[] args)
        {

            XDocument xDoc = XDocument.Load("..\\..\\..\\catalog.xml");
            string query = "catalog/album[year<" + DateTime.Now.Year.ToString() + "]";
            var albums =
                from album in xDoc.Descendants("album")
                where int.Parse(album.Element("year").Value) < DateTime.Now.Year
                select new { Name = album.Element("name").Value, Price = album.Element("price").Value };

            foreach (var album in albums)
            {
                Console.WriteLine("Name: {0}, Price: {1}", album.Name, album.Price);
            }
        }
    }
}
