using System.ComponentModel.DataAnnotations;

namespace Demo_WebAPI_01.API.Dtos
{
    public class PaginationQueryDto
    {
        [Range(0, int.MaxValue)]
        public int Offset { get; set; } = 0;

        [Range(0, 100)]
        public int Limit { get; set; } = 10;
    }
}
