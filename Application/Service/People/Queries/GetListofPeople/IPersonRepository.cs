using Domain.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.People.Queries.GetWithLambda
{
    public interface IPersonRepository
    {
        List<Person> GetPeopleLambda();
        List<Person> GetPeopleLinq();
        string GetPeoplTSQL();
    }
}
