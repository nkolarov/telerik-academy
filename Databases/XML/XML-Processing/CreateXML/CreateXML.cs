// ********************************
// <copyright file="CreateXML.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace CreateXML
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// Demonstrates how to create XML document.
    /// </summary>
    public class CreateXML
    {
        /* 07. In a text file we are given the name, address and phone number of given person (each at a single line). 
         * Write a program, which creates new XML document, which contains these data in structured XML format.*/
        public static void Main()
        {
            using (StreamReader sr = new StreamReader("..\\..\\person.txt"))
            {
                var name = sr.ReadLine();
                var address = sr.ReadLine();
                var phone = sr.ReadLine();

                WriteWithXMLWriter(name, address, phone);

                WriteWithXElement(name, address, phone);

            }
            
            
        }

        private static void WriteWithXElement(string name, string address, string phone)
        {
            XElement person =
                new XElement("person",
                       new XElement("name", name),
                       new XElement("address", address),
                       new XElement("phone", phone)
                 );
            person.Save("..\\..\\personX.xml");
        }

        /// <summary>
        /// Creates an xml file using xml writer.
        /// </summary>
        /// <param name="name">Person`s name.</param>
        /// <param name="address">Person`s address.</param>
        /// <param name="phone">Person`s address.</param>
        private static void WriteWithXMLWriter(string name, string address, string phone)
        {
            XmlWriter docWriter = XmlWriter.Create("..\\..\\person.xml");

            docWriter.WriteStartElement("person");
            docWriter.WriteStartElement("name");
            docWriter.WriteValue(name);
            docWriter.WriteEndElement();
            docWriter.WriteStartElement("address");
            docWriter.WriteValue(address);
            docWriter.WriteEndElement();
            docWriter.WriteStartElement("phone");
            docWriter.WriteValue(phone);
            docWriter.Close();
        }
    }
}
