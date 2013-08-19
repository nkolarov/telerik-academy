using BloggingSystem.Models;
using System;
using System.Data.Entity;

namespace BloggingSystem.Data
{
    public class BloggingSystemContext : DbContext
    {
        public BloggingSystemContext() : base("BloggingSystem") { }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(usr => usr.SessionKey)
                .IsFixedLength()
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(usr => usr.AuthCode)
                .IsFixedLength()
                .HasMaxLength(40);

            base.OnModelCreating(modelBuilder);
        }
    }
}
