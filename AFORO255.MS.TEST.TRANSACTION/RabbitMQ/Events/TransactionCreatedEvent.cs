using MS.AFORO255.Cross.RabbitMQ.Src.Events;

namespace AFORO255.MS.TEST.TRANSACTION.RabbitMQ.Events
{
    public class TransactionCreatedEvent : Event
    {
        public TransactionCreatedEvent(int transaccionID, int id_Invoice, decimal amount, string date)
        {
            TransaccionID = transaccionID;
            Id_Invoice = id_Invoice;
            Amount = amount;
            Date = date;
        }

        public int TransaccionID { get; set; }
        public int Id_Invoice { get; set; }
        public decimal Amount { get; set; }
        public string Date { get; set; }
    }
}