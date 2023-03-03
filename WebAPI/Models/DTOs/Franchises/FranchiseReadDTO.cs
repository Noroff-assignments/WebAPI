namespace WebAPI.Models.DTOs.Franchises
{
    public class FranchiseReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string>? Movies { get; set; }
    }
}
