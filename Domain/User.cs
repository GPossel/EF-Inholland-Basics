using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string userId { get; set; }
        public string name { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }

    }
}
