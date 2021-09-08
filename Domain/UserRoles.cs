using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class UserRoles
    {
        [Key]
        public int rolesId { get; set; }
        public string name { get; set; }
        ICollection<User> users { get; set; }
    }
}
