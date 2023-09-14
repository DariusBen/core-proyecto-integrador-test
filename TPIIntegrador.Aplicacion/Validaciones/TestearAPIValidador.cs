using FluentValidation;
using TPIIntegrador.Aplicacion.Modelos;

namespace TPIIntegrador.Aplicacion.Validaciones
{
    public class TestearAPIValidador : AbstractValidator<TestearAPI>
    {
        public TestearAPIValidador()
        {

            RuleFor(rec => rec.TemperatureC).NotNull().GreaterThan(0);
        }
    }
}
