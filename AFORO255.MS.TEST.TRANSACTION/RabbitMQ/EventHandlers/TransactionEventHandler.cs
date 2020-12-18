using AFORO255.MS.TEST.TRANSACTION.Models;
using AFORO255.MS.TEST.TRANSACTION.RabbitMQ.Events;
using AFORO255.MS.TEST.TRANSACTION.Services;
using MS.AFORO255.Cross.RabbitMQ.Src.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.TRANSACTION.RabbitMQ.EventHandlers
{
    public class TransactionEventHandler : IEventHandler<TransactionCreatedEvent>
    {
        private readonly ITransaccionServices _services;

        public TransactionEventHandler(ITransaccionServices services)
        {
            _services = services;
        }
        public Task Handle(TransactionCreatedEvent @event)
        {
            _services.Add(new Transaccion { Amount = @event.Amount, Date = @event.Date, Id_Invoice = @event.Id_Invoice, TransaccionID = @event.TransaccionID });
            return Task.CompletedTask;
        }
    }
}