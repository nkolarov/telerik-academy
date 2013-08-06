using System;
using System.Linq;
using System.Xml;
using Bookstore.Data;

namespace BookstoreSimpleSearch
{
    public static class BookstoreSimpleSearch
    {
        /*Problem 5. Simple Search for Books. */
        static void Main()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("..\\..\\test6.xml");
            string title = xmlDoc.GetChildText("/query/title");
            string author = xmlDoc.GetChildText("/query/author");
            string isbn = xmlDoc.GetChildText("/query/isbn");
            var books = BookstoreDAL.FindBooksByTitleAndAuthorAndISBN(title, author, isbn);
            if (books.Count > 0)
            {
                Console.WriteLine("{0} {1} found:", books.Count, books.Count != 1 ? "books":"book");
                foreach (var book in books)
                {
                    Console.WriteLine("{0} --> {1} {2}", book.Key, book.Value == 0 ? "no" : book.Value.ToString(), book.Value != 1 ? "reviews" : "review");
                }
            }
            else
            {
                Console.WriteLine("Nothing found");
            }
        }

        private static string GetChildText(this XmlNode node, string xpath)
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
