using AFORO255.MS.TEST.SECURITY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.SECURITY.Repository
{
    public interface IUsuarioRepository
    {
        IEnumerable<Usuarios> GetAll();
    }
}