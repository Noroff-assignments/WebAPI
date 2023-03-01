using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
        // found the shortest and longest name in the world
        [Required, MinLength(3), MaxLength(736)]
        public string FullName { get; set; }

        public string? Alias { get; set; }
        public string? Gender { get; set; }
        [Url]
        public string? PictureURL { get; set; }

        // Navigation property
        public ICollection<Movie>? Movies { get; set; }
    }
}
