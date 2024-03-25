using Application.Interface.Context;
using System.Collections.Generic;
using System.Linq;

namespace Application.Service.People.Queries.GetPeople
{
    public partial class GetList : IGetPeopleList
    {
        private readonly IDataBaseContext _context;
        public GetList(IDataBaseContext context)
        {
            _context = context;
        }



        public List<GetPeopleDto> Execute()
        {
            var people = _context.People.AsQueryable();
            return (List<GetPeopleDto>)people.Select(p => new GetPeopleDto
            {
                Id = p.Id,
                FullName = p.FullName,
                Addresses = p.Addresses.Where(c => c.PersonId == p.Id).Select(c => new GetAddressDTO
                {
                    City = c.City,
                    Street = c.Street
                }).ToList()
            }).ToList();
        }
    }
}
