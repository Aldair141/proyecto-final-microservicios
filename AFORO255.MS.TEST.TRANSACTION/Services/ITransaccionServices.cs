using AFORO255.MS.TEST.TRANSACTION.DTOs;
using AFORO255.MS.TEST.TRANSACTION.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.TRANSACTION.Services
{
    public interface ITransaccionServices
    {
        Task<IEnumerable<TransaccionDTO>> GetAll();
        Task<bool> Add(Transaccion transaccion);
    }
}