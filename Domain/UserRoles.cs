using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserRoles
    {
        public int rolesId { get; set; }
        ICollection<User> users { get; set; }
    }
}
