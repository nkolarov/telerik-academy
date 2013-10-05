namespace MoviesInfo.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Actor
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Studio { get; set; }

        [Required]
        public string StudioAddress { get; set; }
    }
}