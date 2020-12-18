using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.PAY.DTOs
{
    public class OperacionDTO
    {
        public int OperacionID { get; set; }
        public int FacturaID { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
    }
}