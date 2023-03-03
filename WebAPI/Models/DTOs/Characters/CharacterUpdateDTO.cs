namespace WebAPI.Models.DTOs.Characters
{
    public class CharacterUpdateDTO
    {
        public string FullName { get; set; }
        public string Alias { get; set; }
        public string Gender { get; set; }
        public string PictureURL { get; set; }
    }
}
