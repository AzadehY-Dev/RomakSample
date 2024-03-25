using System.Collections.Generic;

namespace Domain.User
{
    public class Role
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public ICollection<UserInRole> UserInRoles { get; set; }
    }
}
