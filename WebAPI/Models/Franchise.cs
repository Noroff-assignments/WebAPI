using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Franchise
    {
        [Key]
        public int Id { get; set; }

        [Required, MinLength(2), MaxLength(25)]
        public string Name { get; set; }
        [MaxLength(400)]
        public string? Description { get; set; }

        // Navigation properties
        public virtual ICollection<Movie>? Movies { get; set; }
    }
}
