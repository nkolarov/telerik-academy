using MoviesInfo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MoviesInfo.Data
{
    public class MoviesContext : DbContext
    {
        public MoviesContext() : base("MoviesDb") { }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Actor> Actors { get; set; }
    }
}
