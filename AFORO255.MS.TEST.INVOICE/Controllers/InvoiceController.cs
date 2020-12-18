using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFORO255.MS.TEST.INVOICE.DTOs;
using AFORO255.MS.TEST.INVOICE.Models;
using AFORO255.MS.TEST.INVOICE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AFORO255.MS.TEST.INVOICE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IFacturaServices _facturaServices;

        public InvoiceController(IFacturaServices facturaServices)
        {
            _facturaServices = facturaServices;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Factura> facturas = _facturaServices.GetAll();
            List<FacturaDTO> facturaDTOs = new List<FacturaDTO>();
            foreach (Factura item in facturas)
            {
                facturaDTOs.Add(new FacturaDTO { Estado = item.State, IdFactura = item.IdInvoice, Monto = item.Amount });
            }
            return Ok(facturaDTOs);
        }

        [HttpPatch]
        public IActionResult Update([FromBody] FacturaUpdateDTO facturaUpdateDTO)
        {
            Factura factura = _facturaServices.Get(facturaUpdateDTO.FacturaID);
            if (factura == null)
            {
                return NotFound();
            }

            factura.State = facturaUpdateDTO.Estado;

            if (!_facturaServices.Update(factura))
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Hubo un problema al intentar actualizar la factura { factura.IdInvoice }");
            }

            return Ok();
        }
    }
}