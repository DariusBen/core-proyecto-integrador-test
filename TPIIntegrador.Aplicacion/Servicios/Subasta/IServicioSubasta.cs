
using TPIIntegrador.Dominio.Entidades;

namespace TPIIntegrador.Aplicacion.Servicios
{
    public interface IServicioSubasta
    {
        Task<IEnumerable<Subasta>> ObtenerSubastasAsync();
        Task<Subasta> ObtenerSubastaAsync(int id);
        Task CrearSubastaAsync(Subasta subasta);
        Task ActualizarSubastaAsync(Subasta subasta);
        Task EliminarSubastaAsync(int id);
    }
}