using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using Supermarket.Models;
using Supermarket.Data;

public class Mongo
{

    private static MongoDatabase mongoDB = ConnectToMongoDB("Supermarket");



    public static void SaveReportToMongoDB()
    {
        if (!mongoDB.CollectionExists("ProductReports"))
        {
            mongoDB.CreateCollection("ProductReports");
        }

        MongoCollection productReports = mongoDB.GetCollection("ProductReports");
        productReports.RemoveAll();

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
            var bson = prod.ToBsonDocument();
            productReports.Insert(bson);
        }
    }

    public static void SaveXMLToMongoDB(dynamic expence)
    {
        if (!mongoDB.CollectionExists("XMLReports"))
        {
            mongoDB.CreateCollection("XMLReports");
        }

        MongoCollection xmlReports = mongoDB.GetCollection("XMLReports");
        xmlReports.RemoveAll();


        var bson = expence.ToBsonDocument();
        xmlReports.Insert(bson);
    }

    private static MongoDatabase ConnectToMongoDB(string dbName)
    {
        MongoClient mongoClient = new MongoClient("mongodb://localhost/");
        MongoServer mongoServer = mongoClient.GetServer();
        MongoDatabase mongoDb = mongoServer.GetDatabase(dbName);
        return mongoDb;
    }
}
