using AFORO255.MS.TEST.SECURITY.Models;
using AFORO255.MS.TEST.SECURITY.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.SECURITY.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioServices(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IEnumerable<Usuarios> GetAll()
        {
            return _usuarioRepository.GetAll();
        }

        public bool ValidaSesion(string username, string password)
        {
            IEnumerable<Usuarios> usuarios = _usuarioRepository.GetAll();
            Usuarios usuario = usuarios.Where(x => x.username == username && x.password == password).FirstOrDefault();
            return usuario != null;
        }
    }
}