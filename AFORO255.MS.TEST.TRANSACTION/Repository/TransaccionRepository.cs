using AFORO255.MS.TEST.TRANSACTION.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.TRANSACTION.Repository
{
    public class TransaccionRepository : ITransaccionRepository
    {
        public readonly IMongoDatabase _mongoDatabase = null;
        public TransaccionRepository(IConfiguration configuration)
        {
            MongoClient mongoClient = new MongoClient(configuration["cnmongo"]);
            if (mongoClient != null)
            {
                _mongoDatabase = mongoClient.GetDatabase(configuration["dbmongo"]);
            }
        }
        public IMongoCollection<Transaccion> Transacciones
        {
            get
            {
                return _mongoDatabase.GetCollection<Transaccion>("Transaccion");
            }
        }
    }
}