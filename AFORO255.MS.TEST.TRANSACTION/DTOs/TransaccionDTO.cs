using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.TRANSACTION.DTOs
{
    public class TransaccionDTO
    {
        public int TransaccionID { get; set; }
        public int Id_Invoice { get; set; }
        public decimal Amount { get; set; }
        public string Date { get; set; }
    }
}