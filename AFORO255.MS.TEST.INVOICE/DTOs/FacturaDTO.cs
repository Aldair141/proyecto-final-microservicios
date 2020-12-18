using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.INVOICE.DTOs
{
    public class FacturaDTO
    {
        public int IdFactura { get; set; }
        public decimal Monto { get; set; }
        public int Estado { get; set; }
    }
}