namespace Exam.Data.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Exam.Models;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            UowData uowData = new UowData();
            if (uowData.Tweets.All().Count() > 0)
            {
                return;
            }

            ApplicationUser user = new ApplicationUser() { UserName = "Pesho" };
            
            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                Tweet tweet = new Tweet();
                tweet.Author = user;
                tweet.DatePosted = DateTime.Now.AddDays(-500).AddDays(random.Next(1, 400));
                tweet.Text = "Demo test tweet " + i;
                for (int j = 1000; j < 1010; j++)
                {
                    Tag tag = new Tag();
                    tag.Text = "Sample tag " + j;
                    uowData.Tags.Add(tag);
                    tag.Tweets.Add(tweet);
                    tweet.Tags.Add(tag);
                }

                uowData.Tweets.Add(tweet);
            }

            uowData.SaveChanges();
        }
    }
}
