using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.TRANSACTION.Models
{
    public class Transaccion
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public int TransaccionID { get; set; }
        public int Id_Invoice { get; set; }
        public decimal Amount { get; set; }
        public string Date { get; set; }
    }
}