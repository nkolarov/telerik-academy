using DirectoryStructure;
using Ionic.Zip;
using MySQLGetData.Model;
using Supermarket.Data;
using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingFromExcel
{
    class TransferDataFromExcelToDB
    {
        private static StringBuilder errorLog = new StringBuilder();
        private static string TEMP_DIRECTORY = string.Empty;
        private static Folder ROOT;
        private static StoreContext db = new StoreContext();

        public static void Transfer()
        {
            FillDataInSQL();
            SetTempDirectory();
            UnZipFiles();
            InitializeRootDirectory();
            PrintFolderFilesInfo(ROOT);
        }

        private static void FillDataInSQL()
        {
            using (var superMarketDb = new StoreEntities())
            {
                var measures = superMarketDb.Measures;
                foreach (var measure in measures)
                {
                    db.Measures.Add(new Measure { MeasureName = measure.MeasureName });
                }
                db.SaveChanges();

                var vendors = superMarketDb.Vendors;
                foreach (var vendor in vendors)
                {
                    db.Vendors.Add(new Vendor { VendorName = vendor.VendorName });
                }
                db.SaveChanges();

                var products = superMarketDb.Products;
                foreach (var product in products)
                {
                    db.Products.Add(new Product
                    {
                        VendorID = product.Vendor.ID,
                        ProductName = product.ProductName,
                        MeasureID = product.Measure.ID,
                        BasePrice = product.BasePrice
                    });

                }
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Gets the size of the folder.
        /// </summary>
        /// <returns>The size of the folder in bytes.</returns>
        private static long PrintFolderFilesInfo(Folder folder)
        {
            long sum = 0;

            // Get files sizes for current directory.
            foreach (var file in folder.Files)
            {
                PrintFileData(file.Path);
            }

            // Get childs folders size recuresively.
            foreach (var childFolder in folder.ChildFolders)
            {
                PrintFolderFilesInfo(childFolder);
            }

            return sum;
        }

        private static void PrintFileData(string pathToFile)
        {
            var reportPosition = pathToFile.IndexOf("Report");
            var fileData = pathToFile.Substring(reportPosition + 7, pathToFile.Length - reportPosition - 11);
            DateTime date = DateTime.Parse(fileData.Substring(1, 11));
            var name = fileData.Substring(12);
            //Console.WriteLine(name);

            string provider = "Microsoft.ACE.OLEDB.12.0";
            string properties = "Excel 12.0;HDR=Yes;IMEX=1";
            string connectionString = String.Format("Provider = {0}; Data Source={1}; Extended Properties = \"{2}\"", provider, pathToFile, properties);
            OleDbConnection excelConnection = new OleDbConnection(connectionString);

            excelConnection.Open();

            // Open 03++ xlsx
            // It provides backward compatibility and reads old excel files.
            using (excelConnection)
            {
                // DataTable dtExcelSchema = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                var readHeader = new OleDbCommand("select * from [Sales$B1:E]", excelConnection);
                OleDbDataReader headerData = readHeader.ExecuteReader();
                headerData.Read();
                var header = headerData[0];

                var readTable = new OleDbCommand("select * from [Sales$B3:E]", excelConnection);
                OleDbDataReader data = readTable.ExecuteReader();

                while (data.Read())
                {

                    if (data[0].ToString() == "Total sum:")
                    {
                        continue;
                    }

                    Sale sale = new Sale
                    {
                        ProductID = int.Parse(data["ProductID"].ToString()),
                        Quantity = int.Parse(data["Quantity"].ToString()),
                        Price = decimal.Parse(data["Unit Price"].ToString()),
                        Sum = decimal.Parse(data["Sum"].ToString()),
                        Date = date,
                        SupermarketName = header.ToString()
                    };
                    db.Sales.Add(sale);
                }

                db.SaveChanges();
            }
        }

        /// <summary>
        /// Initializes the root directory.
        /// </summary>
        private static void InitializeRootDirectory()
        {
            ROOT = new Folder(TEMP_DIRECTORY);
            GenerateFolders(ROOT);
        }

        /// <summary>
        /// Unzips files in temp dir.
        /// </summary>
        private static void UnZipFiles()
        {
            using (ZipFile zip = ZipFile.Read("..\\..\\Sample-Sales-Reports.zip"))
            {
                foreach (ZipEntry e in zip)
                {
                    e.Extract(TEMP_DIRECTORY, ExtractExistingFileAction.OverwriteSilently);  // overwrite == true  
                }
            }
        }

        /// <summary>
        /// Sets the temp dir name.
        /// </summary>
        private static void SetTempDirectory()
        {
            DateTime currentTime = DateTime.Now;
            TEMP_DIRECTORY = "..\\..\\Temp-" + String.Format("{0:yyyyMMddhhmmss}", currentTime);
        }

        /// <summary>
        /// Generates the folders.
        /// </summary>
        /// <param name="folder">The folder.</param>
        private static void GenerateFolders(Folder folder)
        {
            try
            {
                var dirs = Directory.GetDirectories(folder.Path);
                var fileNames = Directory.GetFiles(folder.Path);
                var files = GenerateFiles(fileNames);
                folder.Files.AddRange(files);

                // Walk recuresively through all sub folders.
                foreach (var dir in dirs)
                {
                    Folder currentFolder = new Folder(dir);
                    folder.ChildFolders.Add(currentFolder);
                    GenerateFolders(currentFolder);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                errorLog.AppendLine(ex.Message);
                return;
            }
        }

        /// <summary>
        /// Generates file object by given array of fileNames.
        /// </summary>
        /// <param name="filesNames">The files names.</param>
        /// <returns>List of file oblects.</returns>
        private static List<ReportFile> GenerateFiles(string[] filesNames)
        {
            List<ReportFile> files = new List<ReportFile>();

            for (int i = 0; i < filesNames.Length; i++)
            {
                files.Add(new ReportFile(filesNames[i]));
            }

            return files;
        }
    }
}
