using AFORO255.MS.TEST.TRANSACTION.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.TRANSACTION.Repository
{
    public interface ITransaccionRepository
    {
        IMongoCollection<Transaccion> Transacciones { get; }
    }
}