// ********************************
// <copyright file="FindAlbumsWithXPath.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace FindAlbumsWithXPath
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// Demonstrates how to search in XML with XPath.
    /// </summary>
    public class FindAlbumsWithXPath
    {
        /* 11. Write a program, which extract from the file catalog.xml the prices for all albums, published 5 years ago or earlier. Use XPath query.*/
        static void Main(string[] args)
        {

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("..\\..\\..\\catalog.xml");
            string query = "catalog/album[year<"+DateTime.Now.Year.ToString()+"]";
            XmlNodeList oldAlbums = xmlDoc.SelectNodes(query);

            foreach (XmlNode album in oldAlbums)
            {
                Console.WriteLine("Name: {0}, Price: {1}", album.SelectSingleNode("name").InnerText, album.SelectSingleNode("price").InnerText);
            }
        }
    }
}
