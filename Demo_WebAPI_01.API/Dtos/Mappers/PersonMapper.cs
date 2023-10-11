﻿using Demo_WebAPI_01.BLL.Models;

namespace Demo_WebAPI_01.API.Dtos.Mappers
{
    public static class PersonMapper
    {
        public static PersonListDto ToListDto(this Person person)
        {
            return new PersonListDto
            {
                PersonId = person.PersonId,
                Pseudo = person.Pseudo
            };
        }

        public static PersonDetailDto ToDetailDto(this Person person)
        {
            return new PersonDetailDto
            {
                PersonId = person.PersonId,
                Pseudo = person.Pseudo,
                Name = person.Firstname + " " + person.Lastname,
                BirthDate = person.BirthDate,
                Hobby = person.Hobby
            };
        }


    }
}
