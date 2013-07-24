using DirectoryStructure;
using GeneratingVendorsSalesReportXML;
using Supermarket.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ReadingFromExcel
{
    public static class MyXMLReader
    {
        private static StoreContext db = new StoreContext();
        private static string XMLReportFileName = "Sales-by-Vendors-report.xml";

        public static void Read()
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlElement rootElement = xmlDocument.CreateElement("sales");

            IEnumerable<SalesReportByVendor> sales;
            string nativeSQLQuery =
                    "SELECT v.VendorName, s.Date, SUM(s.Sum) as [Sum] " +
                    "FROM Sales AS s INNER JOIN Products AS p ON s.ProductID = p.ID " +
                    "INNER JOIN Vendors AS v ON p.VendorID = v.ID " +
                    "GROUP BY v.VendorName, s.Date";

            sales = db.Database.SqlQuery<SalesReportByVendor>(nativeSQLQuery);
            foreach (SalesReportByVendor sale in sales)
            {
                XmlElement saleElement = xmlDocument.CreateElement("sale");
                saleElement.SetAttribute("vendor", sale.VendorName);

                XmlElement summaryElement = xmlDocument.CreateElement("summary");
                summaryElement.SetAttribute("date", sale.Date.ToString("dd-MMM-yyyy", CultureInfo.GetCultureInfo("en-US")));
                summaryElement.SetAttribute("total-sum", sale.Sum.ToString("0.00", CultureInfo.GetCultureInfo("en-US")));
                saleElement.AppendChild(summaryElement);
                rootElement.AppendChild(saleElement);
            }
            xmlDocument.AppendChild(rootElement);

            XmlWriter xmlReportFile = GenerateXMLFile(XMLReportFileName);
            xmlReportFile.WriteStartDocument();
            using (xmlReportFile)
            {
                xmlDocument.WriteTo(xmlReportFile);
            }
            Console.WriteLine(xmlDocument.DocumentElement.OuterXml);

        }

        private static bool CheckXMLFileExists(string fileName, Folder folder)
        {
            bool xmlFileExists = false;

            foreach (var file in folder.Files)
            {
                if (file.Path == fileName)
                {
                    xmlFileExists = true;
                    break;
                }
            }

            return xmlFileExists;
        }

        private static XmlWriter GenerateXMLFile(string fileName)
        {
            XmlWriter file = XmlWriter.Create(fileName);

            return file;
        }
    }
}
