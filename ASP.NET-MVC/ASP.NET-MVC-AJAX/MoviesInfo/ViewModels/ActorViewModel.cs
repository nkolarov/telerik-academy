namespace MoviesInfo.ViewModels
{
    using MoviesInfo.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    public class ActorViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Studio { get; set; }

        [Required]
        public string StudioAddress { get; set; }

        public static Expression<Func<Actor, ActorViewModel>> FromActor
        {
            get
            {
                return actor => new ActorViewModel
                {
                    Id = actor.Id,
                    Name = actor.Name,
                    Studio = actor.Studio,
                    StudioAddress = actor.StudioAddress
                };
            }
        }
    }
}