using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo_WebAPI_01.BLL.Models;

namespace Demo_WebAPI_01.BLL.Interfaces
{
    public interface IPersonService
    {
        Person? GetById(int id);
        IEnumerable<Person> GetAll(int offset = 0, int limit = 10);

        Person Add(Person person);
        bool Delete(int id);

        bool PseudoIsAlreadyUsed(string pseudo);
    }
}
