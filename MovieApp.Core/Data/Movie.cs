using System.ComponentModel.DataAnnotations;

namespace MovieApp.Core.Data
{
    public class Movie : BaseEntity
    {
        [Required(ErrorMessage = "Please enter a title")]
        public string Title { get; set; } = null!;

        [StringLength(150, ErrorMessage = "Length exceeded")]
        public string? ShortDescription { get; set; }

        [Required(ErrorMessage = "Please enter the release year")]
        [Range(1900, 2100, ErrorMessage = "Please enter a year between 1900 and 2100")]
        public DateTime ReleaseYear { get; set; }

        [Required(ErrorMessage = "Please select a genre")]
        public Genre Genre { get; set; }

        [StringLength(350, ErrorMessage = "Length exceeded")]
        public string? LongDescription { get; set; }

        [StringLength(150, ErrorMessage = "Length exceeded")]
        public string? DirectorName { get; set; }

        [StringLength(150, ErrorMessage = "Length exceeded")]
        public string? MainCast { get; set; }
    }

}
