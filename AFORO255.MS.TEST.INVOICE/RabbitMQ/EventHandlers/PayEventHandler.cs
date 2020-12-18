using AFORO255.MS.TEST.INVOICE.Models;
using AFORO255.MS.TEST.INVOICE.RabbitMQ.Events;
using AFORO255.MS.TEST.INVOICE.Services;
using MS.AFORO255.Cross.RabbitMQ.Src.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.INVOICE.RabbitMQ.EventHandlers
{
    public class PayEventHandler : IEventHandler<PayCreatedEvent>
    {
        private readonly IFacturaServices _facturaServices;

        public PayEventHandler(IFacturaServices facturaServices)
        {
            _facturaServices = facturaServices;
        }
        public Task Handle(PayCreatedEvent @event)
        {
            _facturaServices.Update(new Factura { Amount = @event.Monto, IdInvoice = @event.FacturaID, State = @event.Estado });
            return Task.CompletedTask;
        }
    }
}
