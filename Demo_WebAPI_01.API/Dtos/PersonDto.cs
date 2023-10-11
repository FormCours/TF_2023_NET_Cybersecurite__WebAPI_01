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
}
