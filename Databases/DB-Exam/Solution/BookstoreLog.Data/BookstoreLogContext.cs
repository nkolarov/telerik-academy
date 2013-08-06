using System;
using System.Data.Entity;
using BookstoreLog.Model;

namespace BookstoreLog.Data
{
    public class BookstoreLogContext : DbContext
    {
        public BookstoreLogContext()
            : base("Logs")
        { }

        public DbSet<SearchLog> SearchLog { get; set; }
    }
}
