using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Invoice
    {
        [Key]
        public string invoiceId { get; set; }

    }
}
