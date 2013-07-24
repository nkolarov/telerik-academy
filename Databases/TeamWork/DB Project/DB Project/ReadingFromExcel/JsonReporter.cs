using Newtonsoft.Json;
using Supermarket.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingFromExcel
{
    public static class JsonReporter
    {
        public static void JsonReport()
        {
            StoreContext db = new StoreContext();
            var queryProducts =
                                     from vendors in db.Vendors
                                     join products in db.Products
                                     on vendors.ID equals products.VendorID
                                     join sales in db.Sales
                                     on products.ID equals sales.ProductID
                                     select new
                                     {
                                         ProductId = products.ID,
                                         PriductName = products.ProductName,
                                         VendorName = vendors.VendorName,
                                         Quantity = sales.Quantity,
                                         Income = sales.Sum
                                     };

            var goupedProducts = from products in queryProducts
                                 group products by products.ProductId into p
                                 select new
                                 {
                                     ProductId = p.Select(a => a.ProductId).FirstOrDefault(),
                                     ProductName = p.Select(a => a.PriductName).FirstOrDefault(),
                                     VendorName = p.Select(a => a.VendorName).FirstOrDefault(),
                                     TotalQuantitySold = p.Sum(a => a.Quantity),
                                     TotalIncomes = p.Sum(a => a.Income)
                                 };
            foreach (var prod in goupedProducts)
            {
                string json = JsonConvert.SerializeObject(prod);
                string fileName = string.Format("..//..//Product-Reports//{0}.json", prod.ProductId);
                StreamWriter sw = new StreamWriter(fileName);
                using (sw)
                {
                    sw.Write(json);
                }
            }
        }
    }
}
