namespace StudentSystem.Data.Migrations
{
    using StudentSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystem.Data.StudentSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        /*03. Seed the data with random values.*/
        protected override void Seed(StudentSystem.Data.StudentSystemContext context)
        {
            context.Students.AddOrUpdate(
                s => s.Name,
                new Student()
                {
                    Name = "Pesho_Zlia",
                    Number = 999
                }
            );
            context.SaveChanges();
        }
    }
}
