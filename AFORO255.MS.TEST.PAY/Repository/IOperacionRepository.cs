using AFORO255.MS.TEST.PAY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.PAY.Repository
{
    public interface IOperacionRepository
    {
        IEnumerable<Operacion> GetAll();
        Operacion Add(Operacion operacion);
    }
}