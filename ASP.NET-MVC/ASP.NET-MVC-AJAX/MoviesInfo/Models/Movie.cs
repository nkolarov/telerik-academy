namespace MoviesInfo.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength=2)]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        public virtual Actor LandingMaleRole { get; set; }

        public virtual Actor LandingFemaleRole { get; set; }
    }
}