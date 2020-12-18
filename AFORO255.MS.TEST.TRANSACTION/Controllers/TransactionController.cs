using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFORO255.MS.TEST.TRANSACTION.DTOs;
using AFORO255.MS.TEST.TRANSACTION.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AFORO255.MS.TEST.TRANSACTION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransaccionServices _transaccionServices;

        public TransactionController(ITransaccionServices transaccionServices)
        {
            _transaccionServices = transaccionServices;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<TransaccionDTO> resultado = _transaccionServices.GetAll().Result;
            return Ok(resultado);
        }
    }
}