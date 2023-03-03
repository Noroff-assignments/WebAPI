namespace WebAPI.Models.DTOs
{
    public class MovieReadDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string ReleaseYear { get; set; }
        public string Director { get; set; }
        public string PosterURL { get; set; }
        public string TrailerURL { get; set; }

        public List<string>? Characters { get; set; }
        public int FranchiseId { get; set; }
    }
}
