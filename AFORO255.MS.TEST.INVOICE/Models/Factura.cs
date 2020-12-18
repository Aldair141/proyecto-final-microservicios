using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.INVOICE.Models
{
    [Table("facturas")]
    public class Factura
    {
        [Key]
        [Column("id_invoice")]
        public int IdInvoice { get; set; }
        [Column("amount")]
        public decimal Amount { get; set; }
        [Column("state")]
        public int State { get; set; }
    }
}