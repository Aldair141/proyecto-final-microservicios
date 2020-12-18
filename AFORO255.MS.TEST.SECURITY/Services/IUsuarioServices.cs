using AFORO255.MS.TEST.SECURITY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.SECURITY.Services
{
    public interface IUsuarioServices
    {
        IEnumerable<Usuarios> GetAll();
        bool ValidaSesion(string usuario, string password);
    }
}