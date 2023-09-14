using Microsoft.AspNetCore.Mvc;
using TPIIntegrador.API.Filtros;
using TPIIntegrador.Aplicacion.Modelos;
using TPIIntegrador.Aplicacion.Servicios;
using TPIIntegrador.Dominio.Entidades;

namespace TPIIntegrador.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [TypeFilter(typeof(FiltroExcepcion))]
    public class SubastaController : ControllerBase
    {

        private readonly IServicioSubasta _servicioSubasta;

        public SubastaController(IServicioSubasta servicioSubasta)
        {
            _servicioSubasta = servicioSubasta;
        }

        [HttpPost]
        [Route("crearsubasta")]
        public async Task<IActionResult> CrearSubastaAsync([FromBody] Subasta subasta)
        {
            await _servicioSubasta.CrearSubastaAsync(subasta);

            return Ok(new Respuesta<Subasta> { estado = true, valor = subasta, mensaje = "Grabo Ok"} );  
        }

        [HttpGet]
        [Route("obtenersubastas")]
        public async Task<IActionResult> ObtenerSubastasAsync()
        {
            IEnumerable<Subasta> subastas = await _servicioSubasta.ObtenerSubastasAsync();

            return Ok(new Respuesta<IEnumerable<Subasta>> { estado = true, valor = subastas});
        }

    }
}
