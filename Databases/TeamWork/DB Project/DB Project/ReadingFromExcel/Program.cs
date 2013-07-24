using DirectoryStructure;
using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.OpenAccess;
using MySQLGetData.Model;
using Supermarket.Data;
using Supermarket.Models;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Xml;
using GeneratingVendorsSalesReportXML;
using System.Globalization;
using Newtonsoft.Json;
using ReadingFromExcel;

namespace ReadingFromExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            //XMLInterpreter.Generate();
            //XMLInterpreter.ReadXml();

            TransferDataFromExcelToDB.Transfer();
            MyXMLReader.Read();
            CreatePDF();
            JsonReporter.JsonReport();
            Mongo.SaveReportToMongoDB();
        }
        

  

        static void CreatePDF()
        {
            StoreContext db = new StoreContext();
            var dataCount = db.Sales.Select(d => d.Date).Distinct().ToList();

            var res = db.Vendors.Find(1);
            Console.WriteLine();

            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wrl = PdfWriter.GetInstance(doc, new FileStream("test.pdf", FileMode.Create));
            doc.Open();

            PdfPTable titleHeader = new PdfPTable(1);
            PdfPCell cellHeader = new PdfPCell(new Phrase("Aggregated Sales Report"));
            cellHeader.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            titleHeader.AddCell(cellHeader);
            doc.Add(titleHeader);

            decimal grandTotalSum = 0;
            foreach (var date in dataCount)
            {
                PdfPTable tableHeader = new PdfPTable(5);
                {
                    PdfPCell cellHeaderDate = new PdfPCell(new Phrase("Data: " + date.ToShortDateString()));
                    cellHeaderDate.Colspan = 5;
                    cellHeaderDate.BackgroundColor = new BaseColor(217, 217, 217);

                    PdfPCell product = new PdfPCell(new Phrase("Product"));
                    product.BackgroundColor = new BaseColor(217, 217, 217);

                    PdfPCell quantity = new PdfPCell(new Phrase("Quantity"));
                    quantity.BackgroundColor = new BaseColor(217, 217, 217);

                    PdfPCell unitPrice = new PdfPCell(new Phrase("Unit Price"));
                    unitPrice.BackgroundColor = new BaseColor(217, 217, 217);

                    PdfPCell location = new PdfPCell(new Phrase("Location"));
                    location.BackgroundColor = new BaseColor(217, 217, 217);

                    PdfPCell sum = new PdfPCell(new Phrase("sum"));
                    sum.BackgroundColor = new BaseColor(217, 217, 217);

                    tableHeader.AddCell(cellHeaderDate);
                    tableHeader.AddCell(product);
                    tableHeader.AddCell(quantity);
                    tableHeader.AddCell(unitPrice);
                    tableHeader.AddCell(location);
                    tableHeader.AddCell(sum);

                }

                decimal totalSum = 0;


                PdfPTable tableBody = new PdfPTable(5);
                {
                    var sales = db.Sales.Where(s => s.Date == date).ToList();
                    tableBody.DefaultCell.HorizontalAlignment = 1;

                    foreach (var sale in sales)
                    {
                        tableBody.AddCell(db.Products.Find(sale.ProductID).ProductName);
                        tableBody.AddCell(sale.Quantity.ToString());
                        tableBody.AddCell(sale.Price.ToString());
                        tableBody.AddCell(sale.SupermarketName);
                        tableBody.AddCell(sale.Sum.ToString());

                        totalSum += sale.Sum;
                    }
                    grandTotalSum += totalSum;
                }
                
                PdfPTable tableFooter = new PdfPTable(5);
                {
                    PdfPCell TotalSumTextCell = new PdfPCell(new Phrase("Total sum for " + date.ToShortDateString() + ": "));
                    TotalSumTextCell.Colspan = 4;
                    TotalSumTextCell.HorizontalAlignment = 2;
                    tableFooter.AddCell(TotalSumTextCell);

                    PdfPCell TotalSumCell = new PdfPCell(new Phrase(totalSum.ToString()));
                    TotalSumCell.HorizontalAlignment = 2;
                    tableFooter.AddCell(TotalSumCell);
                }

                doc.Add(tableHeader);
                doc.Add(tableBody);
                doc.Add(tableFooter);
            }

            PdfPTable footer = new PdfPTable(5);

            PdfPCell GrandSumTextCell = new PdfPCell(new Phrase("Grand total: "));
            GrandSumTextCell.Colspan = 4;
            GrandSumTextCell.HorizontalAlignment = 2;
            footer.AddCell(GrandSumTextCell);

            PdfPCell GrandSumCell = new PdfPCell(new Phrase(grandTotalSum.ToString()));
            GrandSumCell.HorizontalAlignment = 2;
            footer.AddCell(GrandSumCell);

            doc.Add(footer);
            doc.Close();

        }
    }
}
