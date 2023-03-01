using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required, MinLength(1), MaxLength(150)]
        public string Title { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public int ReleaseYear { get; set; }
        [Required, MinLength(3), MaxLength(736)]
        public string Director { get; set; }
        [Url]
        public string? PosterURL { get; set; }
        [Url]
        public string? TrailerURL { get; set; }

        public virtual ICollection<Character>? Characters { get; set; }

        // Navigation properties
        public int FranchiseId { get; set; }
        public Franchise? Franchise { get; set; }
    }
}
