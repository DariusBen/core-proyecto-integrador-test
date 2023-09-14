using Microsoft.AspNetCore.Mvc;
using TPIIntegrador.API.Filtros;
using TPIIntegrador.Aplicacion.Modelos;
using TPIIntegrador.Aplicacion.Servicios;

namespace TPIIntegrador.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [TypeFilter(typeof(FiltroExcepcion))]
    public class UsuarioController : ControllerBase
    {

        private readonly IServicioUsuario _usuarioServicio;

        public UsuarioController(IServicioUsuario usuarioServicio)
        {
            _usuarioServicio = usuarioServicio; 
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Autenticar([FromBody] Login login)
        {
            RespuestaLogin respuestaLogin = await _usuarioServicio.Autenticar(login);

            if ( respuestaLogin.Usuario != null)
            {
                return Ok(respuestaLogin);  
            }

            return Unauthorized(respuestaLogin);
        }

    }
}
