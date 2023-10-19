using MovieApp.Enums;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        [Display(Name ="Genre of the movie")]
        public Genre Genre { get; set; }

        [Display(Name = "Release year")]
        public DateTime ReleaseYear { get; set; }

        [Display(Name = "Short description")]
        public string? ShortDescription { get; set; }

        [Display(Name = "Brief description")]
        public string? LongDescription { get; set; }

        [Display(Name = "Director name")]
        public string? DirectorName { get; set; }

        [Display(Name = "Main cast")]
        public string? MainCast { get; set; }
    }
}
