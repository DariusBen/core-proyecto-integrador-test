using Microsoft.AspNetCore.Mvc;
using System;
using TPIIntegrador.Aplicacion.Modelos;
using TPIIntegrador.API.Controllers;
using TPIIntegrador.Aplicacion.Validaciones;
using TPIIntegrador.Aplicacion.Servicios;

namespace TPIIntegrador.PruebasUnitarias.Api
{
    public class PruebasUnitariasApi
    {
        [Fact]
        public async Task ListarDatosDeberiaRetornarOkConDatos()
        {
            var ServicioDatos = new ServicioDatosPrueba();
            var controller = new HomeController(ServicioDatos);

            var resultado = await controller.ListarDatos();

            // Assert
            var okResultado = Assert.IsType<OkObjectResult>(resultado);
            var respuesta = Assert.IsType<Respuesta<IEnumerable<TestearAPI>>>(okResultado.Value);
            Assert.NotNull(respuesta.valor);
        }
        [Fact]
        public async Task DebeValidarQueTemperaturaCDebeSerMayorACero()
        {

            var eTestApi = new TestearAPI
            {
                Date = DateTime.Now.AddDays(3),
                TemperatureC = 0,
                Summary = "Test"
            };

            var validator = new TestearAPIValidador();

            Assert.False(validator.Validate(eTestApi).IsValid);

        }
    }
}