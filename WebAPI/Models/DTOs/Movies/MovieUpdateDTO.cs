namespace WebAPI.Models.DTOs.Movies
{
    public class MovieUpdateDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string ReleaseYear { get; set; }
        public string Director { get; set; }
        public string PosterURL { get; set; }
        public string TrailerURL { get; set; }
    }
}
