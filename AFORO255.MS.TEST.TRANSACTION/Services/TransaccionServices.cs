using AFORO255.MS.TEST.TRANSACTION.DTOs;
using AFORO255.MS.TEST.TRANSACTION.Models;
using AFORO255.MS.TEST.TRANSACTION.Repository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.TRANSACTION.Services
{
    public class TransaccionServices : ITransaccionServices
    {
        private readonly ITransaccionRepository _transaccionRepository;

        public TransaccionServices(ITransaccionRepository transaccionRepository)
        {
            _transaccionRepository = transaccionRepository;
        }
        public async Task<bool> Add(Transaccion transaccion)
        {
            await _transaccionRepository.Transacciones.InsertOneAsync(transaccion);
            return true;
        }

        public async Task<IEnumerable<TransaccionDTO>> GetAll()
        {
            IEnumerable<Transaccion> data = await _transaccionRepository.Transacciones.Find(_ => true).ToListAsync();
            List<TransaccionDTO> response = new List<TransaccionDTO>();

            foreach (Transaccion item in data)
            {
                response.Add(new TransaccionDTO
                {
                    Amount = item.Amount,
                    Date = item.Date,
                    Id_Invoice = item.Id_Invoice,
                    TransaccionID = item.TransaccionID
                });
            }

            return response;
        }
    }
}