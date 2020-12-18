using MS.AFORO255.Cross.RabbitMQ.Src.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.PAY.RabbitMQ.Events
{
    public class PayCreatedEvent : Event
    {
        public int FacturaID { get; set; }
        public int Estado { get; set; }
        public decimal Monto { get; set; }
        public PayCreatedEvent(int facturaid, int estado, decimal monto)
        {
            FacturaID = facturaid;
            Estado = estado;
            Monto = monto;
        }
    }
}