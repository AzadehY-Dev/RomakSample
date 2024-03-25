using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Person
{
    public class Person
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
