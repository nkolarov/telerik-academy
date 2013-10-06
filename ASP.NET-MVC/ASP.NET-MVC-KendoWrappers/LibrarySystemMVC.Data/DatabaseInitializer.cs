using LibrarySystemMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemMVC.Data
{
    public class DatabaseInitializer : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public DatabaseInitializer()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (context.Books.Count() > 0 || context.Categories.Count() > 0)
            {
                return;
            }

            Random rand = new Random();



            for (int i = 0; i < 10; i++)
            {
                Category cat = new Category();
                cat.Title = "Category " + i;

                for (int j = 0; j < 10; j++)
                {
                    Book book = new Book();
                    book.Title = "Book " + i + " " + j;
                    book.Author = "Author" + i + " " + j;
                    book.Description = "Description" + i + " " + j;
                    book.PublishDate = DateTime.Now.AddYears(-200).AddMonths(rand.Next(10, 1000));
                    cat.Books.Add(book);
                }

                context.Categories.Add(cat);
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
