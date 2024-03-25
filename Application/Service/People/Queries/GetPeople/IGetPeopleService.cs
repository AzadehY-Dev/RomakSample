using Domain.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.People.Queries.GetPeople
{
    public interface IGetPeopleList
    {
        List<GetPeopleDto> Execute();
    }
}
