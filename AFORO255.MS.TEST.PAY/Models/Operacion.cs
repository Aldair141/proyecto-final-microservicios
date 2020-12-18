using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.PAY.Models
{
    public class Operacion
    {
        [Key]
        [Column("id_operation")]
        public int OperacionID { get; set; }
        [Column("id_invoice")]
        public int FacturaID { get; set; }
        [Column("amount")]
        public decimal Monto { get; set; }
        [Column("date")]
        public DateTime Fecha { get; set; }
    }
}