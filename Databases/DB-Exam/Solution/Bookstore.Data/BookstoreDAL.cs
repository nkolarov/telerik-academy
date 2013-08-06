using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Data
{
    public static class BookstoreDAL
    {
        public static void SimpleBookAdd(string title, string authorName, string isbn, string price, string webSiteURL)
        {
            BookstoreEntities context = new BookstoreEntities();
            Book newBook = new Book();
            Author bookAuthor = CreateOrLoadAuthor(context, authorName);
            newBook.Authors.Add(bookAuthor);
            newBook.Title = title;
            newBook.WebSiteURL = webSiteURL;
            if (isbn != string.Empty && isbn != null)
            {
                newBook.ISBN = long.Parse(isbn);
            }

            if (price != string.Empty && price != null)
            {
                newBook.Price = decimal.Parse(price);
            }

            context.Books.Add(newBook);
            context.SaveChanges();
        }
        
        public static void ComplexBookAdd(string title, string isbn, string price, string webSiteURL, List<string> authors, List<Dictionary<string, string>> reviews)
        {
            BookstoreEntities context = new BookstoreEntities();
            Book newBook = new Book();

            foreach (var author in authors)
            {
                Author bookAuthor = CreateOrLoadAuthor(context, author);
                newBook.Authors.Add(bookAuthor);
            }

            foreach (var review in reviews)
            {
                Review bookReview = new Review();
                if (review["author"] != null && review["author"] != string.Empty)
                {
                    Author reviewAuthor = CreateOrLoadAuthor(context, review["author"]);
                    bookReview.Author = reviewAuthor;
                }
                bookReview.Text = review["text"];
                var creationDate = DateTime.Now;
                if (review["creationDate"] != null && review["creationDate"] != string.Empty)
                {
                    creationDate = DateTime.Parse(review["creationDate"]);
                }
                bookReview.CreationDate = creationDate;
                newBook.Reviews.Add(bookReview);
            }

            newBook.Title = title;
            newBook.WebSiteURL = webSiteURL;
            if (isbn != string.Empty && isbn != null)
            {
                newBook.ISBN = long.Parse(isbn);
            }

            if (price != string.Empty && price != null)
            {
                newBook.Price = decimal.Parse(price);
            }
            context.Books.Add(newBook);
            context.SaveChanges();
        }

        private static Author CreateOrLoadAuthor(BookstoreEntities context, string authorName)
        {
            Author existingAuthor =
                (from u in context.Authors
                 where u.Name.ToLower() == authorName.ToLower()
                 select u).FirstOrDefault();
            if (existingAuthor != null)
            {
                return existingAuthor;
            }

            Author newAuthor = new Author();
            newAuthor.Name = authorName;
            context.Authors.Add(newAuthor);
            context.SaveChanges();

            return newAuthor;
        }

        public static Dictionary<string, int> FindBooksByTitleAndAuthorAndISBN(string title, string author, string isbn)
        {
            /*Problem 5. Simple Search for Books. */
            Dictionary<string, int> booksReviews = new Dictionary<string, int>();

            BookstoreEntities context = new BookstoreEntities();
            var booksQuery =
                from b in context.Books.Include("Reviews")
                select b;
            if (title != null)
            {
                booksQuery =
                    from b in context.Books
                    where b.Title.ToLower() == title.ToLower()
                    select b;
            }

            if (isbn != null && isbn != string.Empty)
            {
                long isbnNumber = long.Parse(isbn);
                booksQuery =
                    from b in context.Books
                    where b.ISBN == isbnNumber
                    select b;
            }

            if (author != null)
            {
                booksQuery = booksQuery.Where(
                    b => b.Authors.Any(a => a.Name.ToLower() == author.ToLower()));
            }

            booksQuery = booksQuery.OrderBy(b => b.Title);

            var booksData = booksQuery.Select(b => new {b.Title, b.Reviews.Count});

            foreach (var book in booksData)
            {
                booksReviews.Add(book.Title, book.Count);
            }

            return booksReviews;
        }

        public static IList<Review> FindReviewsByPeriod(DateTime startDate, DateTime endDate)
        {
            BookstoreEntities context = new BookstoreEntities();
            var reviewsQuery =
                from r in context.Reviews.Include("Book").Include("Author").Include("Book.Authors")
                where r.CreationDate >= startDate && r.CreationDate <= endDate
                select r;
            reviewsQuery = reviewsQuery.OrderBy(r => r.CreationDate).ThenBy(r => r.Text);
            return reviewsQuery.ToList();
        }

        public static IList<Review> FindReviewsByAuthor(string authorName)
        {
            BookstoreEntities context = new BookstoreEntities();
            var reviewsQuery =
                from r in context.Reviews.Include("Book").Include("Author").Include("Book.Authors")
                where r.Author.Name == authorName
                select r;
            reviewsQuery = reviewsQuery.OrderBy(r => r.CreationDate).ThenBy(r => r.Text);
            return reviewsQuery.ToList();
        }
    }
}
