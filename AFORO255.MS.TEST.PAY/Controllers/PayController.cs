using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFORO255.MS.TEST.PAY.DTOs;
using AFORO255.MS.TEST.PAY.Models;
using AFORO255.MS.TEST.PAY.RabbitMQ.Commands;
using AFORO255.MS.TEST.PAY.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MS.AFORO255.Cross.RabbitMQ.Src.Bus;

namespace AFORO255.MS.TEST.PAY.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayController : ControllerBase
    {
        private readonly IOperacionServices _serv;
        private readonly IEventBus _bus;

        public PayController(IOperacionServices serv, IEventBus bus)
        {
            _serv = serv;
            _bus = bus;
        }

        [HttpPost]
        public IActionResult Add([FromBody] OperacionAddDTO operacionAddDTO)
        {
            if (operacionAddDTO.Monto <= 0)
            {
                return BadRequest("Monto no válido.");
            }

            Operacion operacion = new Operacion
            {
                FacturaID = operacionAddDTO.FacturaID,
                Monto = operacionAddDTO.Monto,
                Fecha = DateTime.Now
            };

            operacion = _serv.Add(operacion);

            if (operacion == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"No se pudo registar el pago de la factura { operacionAddDTO.FacturaID }.");
            }
            else
            {
                //Publicar la factura en la cola
                PayCreatedCommand comando = new PayCreatedCommand(operacion.FacturaID, 1, operacion.Monto);
                _bus.SendCommand(comando);

                //Publicar la transaccion en la cola
                TransactionCreatedCommand comando2 = new TransactionCreatedCommand(operacion.OperacionID, operacion.FacturaID, operacion.Monto, operacion.Fecha.ToShortDateString());
                _bus.SendCommand(comando2);
            }

            return Ok(operacion);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Operacion> operacionesBD = _serv.GetAll();
            List<OperacionDTO> operacionesDTO = new List<OperacionDTO>();
            foreach (Operacion item in operacionesBD)
            {
                operacionesDTO.Add(new OperacionDTO { OperacionID = item.OperacionID, FacturaID = item.FacturaID, Fecha = item.Fecha, Monto = item.Monto });
            }
            return Ok(operacionesDTO);
        }
    }
}