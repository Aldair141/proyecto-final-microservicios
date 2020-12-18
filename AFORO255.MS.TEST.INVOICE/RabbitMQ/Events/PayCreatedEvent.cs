using MS.AFORO255.Cross.RabbitMQ.Src.Events;

namespace AFORO255.MS.TEST.INVOICE.RabbitMQ.Events
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