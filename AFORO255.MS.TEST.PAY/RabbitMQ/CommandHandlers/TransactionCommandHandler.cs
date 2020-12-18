using AFORO255.MS.TEST.PAY.RabbitMQ.Commands;
using AFORO255.MS.TEST.PAY.RabbitMQ.Events;
using MediatR;
using MS.AFORO255.Cross.RabbitMQ.Src.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.PAY.RabbitMQ.CommandHandlers
{
    public class TransactionCommandHandler : IRequestHandler<TransactionCreatedCommand, bool>
    {
        private readonly IEventBus _bus;

        public TransactionCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }
        public Task<bool> Handle(TransactionCreatedCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new TransactionCreatedEvent(request.TransaccionID, request.Id_Invoice, request.Amount, request.Date));
            return Task.FromResult(true);
        }
    }
}