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
        [Column("FirstName")]
        [MaxLength(60)]
        [Required]
        public string name { get; set; }
        [NotMapped]
        public int age { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<UserRoles> roles { get; set; }
    }
}
