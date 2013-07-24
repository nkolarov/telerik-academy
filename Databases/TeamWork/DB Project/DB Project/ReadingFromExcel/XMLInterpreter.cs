using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MongoDB;
using System.IO;
using System.Data;
using System.Data.Entity;
using System.Xml.Schema;
using Supermarket.Data;
using Supermarket.Models;

namespace ReadingFromExcel
{
    public static class XMLInterpreter
    {
        private static string XMLReportFileName = "..\\..\\..\\TestingFiles\\Vendors-Expenses.xml";

        public static void ReadXml()
        {
            XmlReaderSettings xmlSettings = new XmlReaderSettings();
            xmlSettings.ValidationType = ValidationType.None;
            xmlSettings.CheckCharacters = false;
            xmlSettings.ConformanceLevel = ConformanceLevel.Auto;
            xmlSettings.CloseInput = true;
            xmlSettings.IgnoreComments = true;
            xmlSettings.IgnoreProcessingInstructions = true;
            xmlSettings.IgnoreWhitespace = true;
            xmlSettings.ValidationFlags |= XmlSchemaValidationFlags.None;

            StreamReader streamReadXMLFile = new StreamReader(XMLReportFileName);
            using (XmlReader reader = XmlReader.Create(streamReadXMLFile, xmlSettings))
            {
                string vendorName = string.Empty;
                string month = String.Empty;
                string expenseValue = String.Empty;

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        switch (reader.Name)
                        {
                            case "sale": vendorName = reader.GetAttribute("vendor");
                                break;
                            case "expenses": month = reader.GetAttribute("month");
                                expenseValue = reader.ReadInnerXml();
                                InsertIntoExpenses(vendorName, month, expenseValue);
                                break;
                        }
                    }
                }
            }
        }

        private static void InsertIntoExpenses(string vendorName, string month, string expenseValue)
        {
            var expence = new
            {
                vendorName = vendorName,
                month = month,
                expenseValue = expenseValue
            };
            Mongo.SaveXMLToMongoDB(expence);
        }
    }

}
