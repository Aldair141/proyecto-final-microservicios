using AFORO255.MS.TEST.PAY.Models;
using AFORO255.MS.TEST.PAY.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.PAY.Repository
{
    public class OperacionRepository : IOperacionRepository
    {
        private readonly IContextDatabase _context;

        public OperacionRepository(IContextDatabase context)
        {
            _context = context;
        }
        public Operacion Add(Operacion operacion)
        {
            _context.Operacion.Add(operacion);
            int filas = _context.SaveChanges();
            if (filas <= 0)
                return null;

            return operacion;
        }

        public IEnumerable<Operacion> GetAll()
        {
            return _context.Operacion.OrderBy(x => x.OperacionID);
        }
    }
}