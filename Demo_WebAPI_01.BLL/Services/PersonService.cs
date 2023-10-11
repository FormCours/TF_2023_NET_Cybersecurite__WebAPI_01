using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo_WebAPI_01.BLL.Interfaces;
using Demo_WebAPI_01.BLL.Models;

namespace Demo_WebAPI_01.BLL.Services
{
    public class PersonService : IPersonService
    {
        #region Local Data -> For demo
        private static readonly List<Person> _People = new List<Person>()
        {
            new Person
            {
                PersonId = 1,
                Pseudo = "SuperDella",
                Firstname = "Della",
                Lastname = "DUCK",
                BirthDate = new DateTime(1988, 11, 13),
                Hobby = "L'espace"
            },
            new Person
            {
                PersonId = 2,
                Pseudo = "Balty",
                Firstname = "Balthazar",
                Lastname = "PICSOU",
                BirthDate = new DateTime(1962, 1, 25),
                Hobby = "Nager dans son argent"
            },
            new Person
            {
                PersonId = 3,
                Pseudo = "Zaz",
                Firstname = "Zaza",
                Lastname = "VANDERQUACK",
                BirthDate = new DateTime(2002, 2, 9),
                Hobby = null
            }
        };
        private static int _NextId = 4;
        #endregion


        public Person Add(Person person)
        {
            if(PseudoIsAlreadyUsed(person.Pseudo))
            {
                throw new Exception("Pseudo is already used (╯°□°）╯︵ ┻━┻");
            }

            Person personToAdd = new Person
            {
                PersonId = _NextId++,
                Pseudo = person.Pseudo,
                Firstname = person.Firstname,
                Lastname = person.Lastname.ToUpper(),
                BirthDate = person.BirthDate,
                Hobby = person.Hobby,
            };

            _People.Add(personToAdd);

            return personToAdd;
        }

        public bool Delete(int id)
        {
            int nbDeleted = _People.RemoveAll(person => person.PersonId == id);
            return nbDeleted == 1;
        }

        public IEnumerable<Person> GetAll(int offset = 0, int limit = 10)
        {
            // Gestion d'un offset plus haut que le nombre d'élément
            if(offset > _People.Count)
            {
                return Enumerable.Empty<Person>();
            }

            return _People.Skip(offset).Take(limit);
        }

        public Person? GetById(int id)
        {
            return _People.SingleOrDefault(person => person.PersonId == id);
        }

        public bool PseudoIsAlreadyUsed(string pseudo)
        {
            return _People.Any(person => string.Equals(person.Pseudo, pseudo, StringComparison.OrdinalIgnoreCase));
        }
    }
}
