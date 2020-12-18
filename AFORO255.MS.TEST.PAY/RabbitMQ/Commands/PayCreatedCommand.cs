using MS.AFORO255.Cross.RabbitMQ.Src.Commands;

namespace AFORO255.MS.TEST.PAY.RabbitMQ.Commands
{
    public class PayCreatedCommand : Command
    {
        public int FacturaID { get; protected set; }
        public int Estado { get; protected set; }
        public decimal Monto { get; protected set; }
        public PayCreatedCommand(int facturaid, int estado, decimal monto)
        {
            FacturaID = facturaid;
            Estado = estado;
            Monto = monto;
        }
    }
}