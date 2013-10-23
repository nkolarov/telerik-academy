namespace Exam.Data.Migrations
{
    using Exam.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (context.Tickets.Count() > 0)
            {
                return;
            }

            Category categoryMVC = new Category() { Name = "ASP.NET-MVC" };
            Category categoryWebForms = new Category() { Name = "ASP.NET-WebForms" };

            ApplicationUser user = new ApplicationUser() { UserName = "peshoTicket", Points = 10 };
            ApplicationUser commenterUser = new ApplicationUser() { UserName = "theCommenter", Points = 10 };

            PopulateTickets(context, categoryMVC, user, commenterUser);

            PopulateTickets(context, categoryWebForms, user, commenterUser);
        }

        private static void PopulateTickets(ApplicationDbContext context, Category category, ApplicationUser user, ApplicationUser commenterUser)
        {
            Random rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                Ticket ticket = new Ticket();
                ticket.ScreenshotURL = "http://www.networkworld.com/Micronet%20images/Bug.png";
                ticket.Title = "Sample ticket " + i + " " + category.Name;
                ticket.Priority = Priority.Medium;
                ticket.Category = category;
                ticket.Author = user;
                ticket.Description = "Sample description " + i + " " + category.Name;
                var count = rand.Next(0, 8);

                for (int j = 0; j < count; j++)
                {
                    Comment comment = new Comment();
                    comment.Author = commenterUser;
                    comment.Content = "Sample comment " + i + " " + j;
                    comment.Ticket = ticket;
                    ticket.Comments.Add(comment);
                }

                context.Tickets.Add(ticket);
            }
        }
    }
}
