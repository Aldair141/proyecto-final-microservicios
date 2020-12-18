using MS.AFORO255.Cross.RabbitMQ.Src.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.PAY.RabbitMQ.Commands
{
    public class TransactionCreatedCommand : Command
    {
        public TransactionCreatedCommand(int transaccionID, int id_Invoice, decimal amount, string date)
        {
            TransaccionID = transaccionID;
            Id_Invoice = id_Invoice;
            Amount = amount;
            Date = date;
        }

        public int TransaccionID { get; protected set; }
        public int Id_Invoice { get; protected set; }
        public decimal Amount { get; protected set; }
        public string Date { get; protected set; }

    }
}