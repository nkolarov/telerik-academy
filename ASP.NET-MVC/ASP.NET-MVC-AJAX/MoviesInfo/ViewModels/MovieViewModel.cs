namespace MoviesInfo.ViewModels
{
    using MoviesInfo.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    public class MovieViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string LandingMaleRoleName { get; set; }

        public string LandingFemaleRoleName { get; set; }

        public int LandingMaleRoleId { get; set; }

        public int LandingFemaleRoleId { get; set; }

        public IEnumerable<SelectListItem> Actors { get; set; }

        public IEnumerable<SelectListItem> Actresses { get; set; }

        public MovieViewModel()
        {
            this.Actors = new List<SelectListItem>();
            this.Actresses = new List<SelectListItem>();
        }

        public static Expression<Func<Movie, MovieViewModel>> FromMovie
        {
            get
            {
                return movie => new MovieViewModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Year = movie.Year,
                    LandingFemaleRoleId = movie.LandingFemaleRole.Id,
                    LandingMaleRoleId = movie.LandingMaleRole.Id,
                    LandingMaleRoleName = movie.LandingMaleRole.Name,
                    LandingFemaleRoleName = movie.LandingFemaleRole.Name
                };
            }
        }
    }
}

