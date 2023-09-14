using Microsoft.AspNetCore.Mvc;
using TPIIntegrador.Aplicacion.Modelos;
using TPIIntegrador.API.Filtros;
using TPIIntegrador.Aplicacion.Servicios;

namespace TPIIntegrador.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [TypeFilter(typeof(FiltroExcepcion))]
    public class HomeController : ControllerBase
    {
  
        private readonly IServicioDatosPrueba _servicioDatosPrueba;


        public HomeController(IServicioDatosPrueba servicioDatosPrueba)
        {
            _servicioDatosPrueba = servicioDatosPrueba;
        }


        [HttpGet]
        [Route("ListarDatos")]
        public async Task<IActionResult> ListarDatos()
        {
            var rsp = new Respuesta<IEnumerable<TestearAPI>>();

            rsp.valor = this._servicioDatosPrueba.ObtenerValores();

            return Ok(rsp);
        }

    }
}