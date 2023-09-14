using FluentValidation;
using TPIIntegrador.Aplicacion.Modelos;

namespace TPIIntegrador.Aplicacion.Validaciones
{
    public class LoginValidador : AbstractValidator<Login>
    {
        public LoginValidador()
        {

            RuleFor(rec => rec.Usuario).NotEmpty();
            RuleFor(rec => rec.Password).NotEmpty();
        }
    }
}
