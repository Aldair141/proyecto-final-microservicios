using AFORO255.MS.TEST.PAY.Models;
using AFORO255.MS.TEST.PAY.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.PAY.Services
{
    public class OperacionServices : IOperacionServices
    {
        private readonly IOperacionRepository _repo;

        public OperacionServices(IOperacionRepository repo)
        {
            _repo = repo;
        }
        public Operacion Add(Operacion operacion)
        {
            return _repo.Add(operacion);
        }

        public IEnumerable<Operacion> GetAll()
        {
            return _repo.GetAll();
        }
    }
}