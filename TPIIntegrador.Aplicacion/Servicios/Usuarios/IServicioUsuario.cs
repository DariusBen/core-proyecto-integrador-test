
using TPIIntegrador.Aplicacion.Modelos;

namespace TPIIntegrador.Aplicacion.Servicios
{
    public interface IServicioUsuario
    {
        public Task<RespuestaLogin> Autenticar(Login login);
    }
}