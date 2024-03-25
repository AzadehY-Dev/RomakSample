using Application.Interface.Context;
using Domain.Person;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Application.Service.People.Queries.GetWithLambda
{
    public class PersonRepository : IPersonRepository
    {
        private readonly string _connectionString;
        private readonly IDataBaseContext _context;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public PersonRepository(IDataBaseContext context, IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnStr");
            _context = context;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                // Other serializer options as needed
            };
        }


        public List<Person> GetPeopleLambda()
        {
            return _context.People.ToList();

        }
        public List<Person> GetPeopleLinq()
        {
            var peopleWithAddresses = (from person in _context.People
                                       select new Person
                                       {
                                           Id = person.Id,
                                           FullName = person.FullName,
                                           Addresses = (from address in person.Addresses
                                                        where address.PersonId == person.Id
                                                        select address).ToList()
                                       }).AsNoTracking().ToList();

            return peopleWithAddresses;
        }

        public string GetPeoplTSQL()
        {
            string query = @" SELECT p.Id, p.FullName, a.Street, a.City FROM People p JOIN Addresses a ON p.Id = a.PersonId";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(query, connection);
                var reader = command.ExecuteReader();

                var people = new List<Person>();
                while (reader.Read())
                {
                    int personId = (int)reader["Id"];
                    string fullName = (string)reader["FullName"];
                    string street = (string)reader["Street"];
                    string city = (string)reader["City"];

                    var person = people.FirstOrDefault(p => p.Id == personId);
                    if (person == null)
                    {
                        person = new Person { Id = personId, FullName = fullName, Addresses = new List<Address>() };
                        people.Add(person);
                    }

                    var address = new Address { Street = street, City = city, Person = person, PersonId = personId };
                    person.Addresses.Add(address);
                }
                string json = JsonSerializer.Serialize(people, _jsonSerializerOptions);
                return json;

            }
        }
    }
}
