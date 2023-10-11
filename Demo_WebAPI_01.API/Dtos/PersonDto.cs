using System.ComponentModel.DataAnnotations;

namespace Demo_WebAPI_01.API.Dtos
{
    public class PersonDetailDto
    {
        public int PersonId { get; set; }
        public string Pseudo { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string? Hobby { get; set; }
    }

    public class PersonListDto
    {
        public int PersonId { get; set; }
        public string Pseudo { get; set; } = string.Empty;
    }

    public class PersonDataDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Pseudo { get; set; } = string.Empty;

        [Required, MinLength(2), MaxLength(50)]
        public string Firstname { get; set; } = string.Empty;

        [Required, MinLength(2), MaxLength(50)]
        public string Lastname { get; set; } = string.Empty;

        [Required]
        public DateTime BirthDate { get; set; }

        public string? Hobby { get; set; }
    }
}
