using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text;
using TPIIntegrador.Aplicacion.Modelos;

namespace TPIIntegrador.API.Filtros
{
    public class FiltroValidacion : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext httpContext)
        {
            if (!httpContext.ModelState.IsValid)
            {
                Respuesta<object> respuesta= new Respuesta<object>();

                respuesta.estado = false;

                var errores = httpContext.ModelState.Values.SelectMany(val => val.Errors);

                respuesta.mensaje = this.ConcatenarErrores(errores);

                httpContext.Result = new JsonResult(respuesta);
            }
        }

        private string ConcatenarErrores(IEnumerable<ModelError> errores)
        {
            var sbErrores = new StringBuilder();

            errores.ToList().ForEach(err => sbErrores.AppendLine(err.ErrorMessage));

            return sbErrores.ToString();
        }
    }
}
