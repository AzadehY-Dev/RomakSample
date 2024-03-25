using System.Collections.Generic;

namespace Application.Service.People.Queries.GetPeople
{
    public class GetPeopleDto
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public List<GetAddressDTO> Addresses { get; set; }
    }
}
