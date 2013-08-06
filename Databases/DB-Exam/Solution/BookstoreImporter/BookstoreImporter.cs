using System;
using System.Collections.Generic;
using System.Transactions;
using System.Xml;
using Bookstore.Data;

namespace BookstoreImporter
{
    public static class BookstoreImporter
    {
        static void Main()
        {
            /* Task 3: Import books from simple xml. */
            // // Uncomment to next line to check the result.
            // SimpleXMLBooksImport();

            /* Task 4: Import books from complex xml. */
            // // Uncomment to next line to check the result.
            ComplexXMLBooksImport();
        }

        private static void ComplexXMLBooksImport()
        {
            /* Task 4: Import books from complex xml. */

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("..\\..\\complex-books.xml");
            string xPathQuery = "/catalog/book";

            XmlNodeList booksList = xmlDoc.SelectNodes(xPathQuery);
            foreach (XmlNode book in booksList)
            {
                /* Inserting a book should be atomic operation.*/
                TransactionScope tran = new TransactionScope(
                    TransactionScopeOption.Required,
                    new TransactionOptions()
                    {
                        IsolationLevel = IsolationLevel.RepeatableRead
                    });
                using (tran)
                {

                    string title = book.GetChildText("title");
                    string isbn = book.GetChildText("isbn");
                    string price = book.GetChildText("price");
                    string webSiteURL = book.GetChildText("web-site");
                    var authors = GetAuthors(book);
                    var reviews = GetReviews(book);
                    var a = 5;
                    BookstoreDAL.ComplexBookAdd(title, isbn, price, webSiteURL, authors, reviews);
                    tran.Complete();
                }

            }
        }

        private static void SimpleXMLBooksImport()
        {
            /* Task 3: Import books from simple xml. */
            TransactionScope tran = new TransactionScope(
            TransactionScopeOption.Required,
                new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.RepeatableRead
                });
            using (tran)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("..\\..\\test1.xml");
                string xPathQuery = "/catalog/book";

                XmlNodeList booksList = xmlDoc.SelectNodes(xPathQuery);
                foreach (XmlNode book in booksList)
                {
                    string authorName = book.GetChildText("author");
                    string title = book.GetChildText("title");
                    string isbn = book.GetChildText("isbn");
                    string price = book.GetChildText("price");
                    string webSiteURL = book.GetChildText("web-site");
                    BookstoreDAL.SimpleBookAdd(title, authorName, isbn, price, webSiteURL);
                    //BookmarksDAL.AddBookmark(username, title, url, tags, notes);
                }
                tran.Complete();
            }
        }

        private static List<Dictionary<string, string>> GetReviews(XmlNode book)
        {
            List<Dictionary<string, string>> reviews = new List<Dictionary<string, string>>();

            XmlNode childNode = book.SelectSingleNode("reviews");
            if (childNode != null)
            {
                for (int i = 0; i < childNode.ChildNodes.Count; i++)
                {
                    var currentReview = childNode.ChildNodes[i];
                    var creationDate = string.Empty;
                    var creationDateAttrib = currentReview.Attributes.GetNamedItem("date");
                    if (creationDateAttrib != null)
                    {
                        creationDate = creationDateAttrib.Value;
                    }

                    var author = string.Empty;
                    var authorAttrib = currentReview.Attributes.GetNamedItem("author");
                    if (authorAttrib != null)
                    {
                        author = authorAttrib.Value;
                    }

                    var currentReviewData = new Dictionary<string, string>();
                    currentReviewData.Add("text", childNode.ChildNodes[i].InnerText.Trim());
                    currentReviewData.Add("creationDate", creationDate);
                    currentReviewData.Add("author", author);
                    reviews.Add(currentReviewData);
                }
            }

            return reviews;
        }

        private static List<string> GetAuthors(XmlNode book)
        {
            var authors = new List<string>();

            XmlNode childNode = book.SelectSingleNode("authors");
            if (childNode != null)
            {
                for (int i = 0; i < childNode.ChildNodes.Count; i++)
                {
                    var currentAuthorName = childNode.ChildNodes[i].InnerText.Trim();
                    authors.Add(currentAuthorName);
                }
            }

            return authors;
        }

        private static string GetChildText(this XmlNode node, string tagName)
        {
            XmlNode childNode = node.SelectSingleNode(tagName);
            if (childNode == null)
            {
                return null;
            }
            return childNode.InnerText.Trim();
        }
    }
}
