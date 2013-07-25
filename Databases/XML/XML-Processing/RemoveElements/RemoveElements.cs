// ********************************
// <copyright file="RemoveElements.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace RemoveElements
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    /// <summary>
    /// Demonstrates how to remove elements form XML document.
    /// </summary>
    public class RemoveElements
    {
        /* 04. Using the DOM parser write a program to delete from catalog.xml all albums having price > 20.*/
        public static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("..\\..\\..\\catalog.xml");
            XmlNode rootNode = doc.DocumentElement;

            // Walk through elements and remove expensive albums.
            for (int i = 0; i < rootNode.ChildNodes.Count; i++)
            {
                XmlNode current = rootNode.ChildNodes[i];
                if (decimal.Parse(current["price"].InnerText) > 20)
                {
                    rootNode.RemoveChild(current);
                    i--;
                }
            }

            // Save to new file and print to console.
            doc.Save("..\\..\\cheap-albums-catalog.xml");
            foreach (XmlNode item in rootNode.ChildNodes)
            {
                Console.WriteLine("{0} -> {1}", item["artist"].InnerText, item["name"].InnerText);
            }
        }
    }
}
