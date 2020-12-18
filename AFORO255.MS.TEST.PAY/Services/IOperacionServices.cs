using AFORO255.MS.TEST.PAY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.PAY.Services
{
    public interface IOperacionServices
    {
        Operacion Add(Operacion operacion);
        IEnumerable<Operacion> GetAll();
    }
}