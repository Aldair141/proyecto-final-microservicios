using AFORO255.MS.TEST.SECURITY.Models;
using AFORO255.MS.TEST.SECURITY.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.SECURITY.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IContextDatabase _contextDatabase;

        public UsuarioRepository(IContextDatabase contextDatabase)
        {
            _contextDatabase = contextDatabase;
        }

        public IEnumerable<Usuarios> GetAll()
        {
            IEnumerable<Usuarios> usuarios = _contextDatabase.Usuarios.ToList();
            return usuarios;
        }
    }
}