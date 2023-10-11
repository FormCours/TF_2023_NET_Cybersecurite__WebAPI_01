using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_WebAPI_01.BLL.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Pseudo { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string? Hobby { get; set; }
    }
}
