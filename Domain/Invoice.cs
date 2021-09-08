using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Invoice
    {
        [Key]
        public string invoiceId { get; set; }
        [ForeignKey("userId")]
        public string userId { get; set; }
        public virtual User user { get; set; }
        public DateTime date { get; set; }
    }
}
