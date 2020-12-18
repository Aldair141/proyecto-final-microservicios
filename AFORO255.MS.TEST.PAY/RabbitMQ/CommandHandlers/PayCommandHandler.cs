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
    public class PayCommandHandler : IRequestHandler<PayCreatedCommand, bool>
    {
        private readonly IEventBus _bus;

        public PayCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }
        public Task<bool> Handle(PayCreatedCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new PayCreatedEvent(request.FacturaID, request.Estado, request.Monto));
            return Task.FromResult(true);
        }
    }
}
