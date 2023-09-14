using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TPIIntegrador.Aplicacion.Modelos;

namespace TPIIntegrador.API.Filtros
{
    public class FiltroExcepcion : IExceptionFilter
    {
        public FiltroExcepcion()
        {
        }

        void IExceptionFilter.OnException(ExceptionContext context)
        {
            Respuesta<object> cRespuesta = new Respuesta<object>();

            cRespuesta.estado = false;

            cRespuesta.mensaje = $"Hubo un error. {context.Exception.Message}";

            context.Result = new JsonResult(cRespuesta);
        }
    }
}
