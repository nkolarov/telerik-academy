using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
using Bookstore.Data;
using BookstoreLog.Data;
using BookstoreLog.Data.Migrations;
using BookstoreLog.Model;

namespace BookstoreComplexSearch
{
    public static class BookstoreComplexSearch
    {
        static void Main()
        {
            /* Problem 6. Search for Reviews*/
            string fileName = "..\\..\\reviews-search-results.xml";
            using (XmlTextWriter writer =
                new XmlTextWriter(fileName, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("search-results");

                ProcessSearchQueries(writer);

                writer.WriteEndDocument();
            }
        }

        private static void ProcessSearchQueries(XmlTextWriter writer)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("..\\..\\performance-test.xml");
            foreach (XmlNode query in xmlDoc.SelectNodes("review-queries/query"))
            {
                SaveQueryToLog(query.OuterXml);
                var type = query.Attributes.GetNamedItem("type");
                switch (type.Value)
                {
                    case "by-period":
                        // Start date and end date are mandatory.
                        DateTime startDate = DateTime.Parse(query.GetChildText("start-date"));
                        DateTime endDate = DateTime.Parse(query.GetChildText("end-date"));
                        var reviewsByPeriod = BookstoreDAL.FindReviewsByPeriod(startDate, endDate);
                        WriteReviews(writer, reviewsByPeriod);
                        break;
                    case "by-author":
                        string authorName = query.GetChildText("author-name");
                        var reviewsByAuthor = BookstoreDAL.FindReviewsByAuthor(authorName);
                        WriteReviews(writer, reviewsByAuthor);
                        break;
                    default:
                        throw new ArgumentException("Type not supported!");
                }
            }
        }

        private static void SaveQueryToLog(string query)
        {
            var queryText = query.ToString();
            using (var logContext = new BookstoreLogContext())
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookstoreLogContext, Configuration>());

                var log = new SearchLog();
                log.Date = DateTime.Now;
                log.Content = queryText;
                logContext.SearchLog.Add(log);
                logContext.SaveChanges();
            }
        }

        private static void WriteReviews(XmlTextWriter writer, IList<Review> reviews)
        {
            writer.WriteStartElement("result-set");
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            foreach (var review in reviews)
            {
                writer.WriteStartElement("review");
                if (review.CreationDate != null)
                {
                    writer.WriteElementString("date", review.CreationDate.ToString("dd-MMM-yyyy"));
                }
                if (review.Text != null)
                {
                    writer.WriteElementString("content", review.Text);
                }
                if (review.Book != null)
                {
                    writer.WriteStartElement("book");
                    var book = review.Book;
                    if (book.Title != null)
                    {
                        writer.WriteElementString("title", book.Title);
                    }

                    if (book.Authors != null)
                    {
                        string authors = string.Join(", ", book.Authors.Select(a => a.Name).OrderBy(a => a));
                        if (authors != null && authors != string.Empty)
                        {
                            writer.WriteElementString("authors", authors);
                        }
                    }

                    if (book.ISBN != null)
                    {
                        writer.WriteElementString("isbn", book.ISBN.ToString());
                    }

                    if (book.WebSiteURL != null)
                    {
                        writer.WriteElementString("url", book.WebSiteURL);
                    }

                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        private static string GetChildText(
            this XmlNode node, string xpath)
        {
            XmlNode childNode = node.SelectSingleNode(xpath);
            if (childNode == null)
            {
                return null;
            }
            return childNode.InnerText.Trim();
        }
    }
}
