using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFORO255.MS.TEST.SECURITY.DTOs;
using AFORO255.MS.TEST.SECURITY.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MS.AFORO255.Cross.Jwt.Src;

namespace AFORO255.MS.TEST.SECURITY.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly IUsuarioServices _usuarioServices;
        private readonly JwtOptions _jwtOptions;

        public SecurityController(IUsuarioServices usuarioServices, IOptionsSnapshot<JwtOptions> jwtOptions)
        {
            _usuarioServices = usuarioServices;
            _jwtOptions = jwtOptions.Value;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_usuarioServices.GetAll());
        }

        [HttpPost]
        public IActionResult Login([FromBody] UsuarioDTO usuarioDTO)
        {
            if (!_usuarioServices.ValidaSesion(usuarioDTO.username, usuarioDTO.password))
            {
                return Unauthorized();
            }

            Response.Headers.Add("access-control-expose-headers", "Authorization");
            Response.Headers.Add("Authorization", JwtToken.Create(_jwtOptions));

            return Ok();
        }
    }
}