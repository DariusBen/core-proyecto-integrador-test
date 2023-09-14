using TPIIntegrador.Dominio.Entidades;
using TPIIntegrador.Dominio.Respositorios;

namespace TPIIntegrador.Aplicacion.Servicios
{
    public class ServicioSubasta : IServicioSubasta
    {
        private readonly IRepositorio<Subasta> _subastaRepositorio;

        public ServicioSubasta(IRepositorio<Subasta> subastaRepositorio)
        {
            _subastaRepositorio = subastaRepositorio;
        }

        public async Task<IEnumerable<Subasta>> ObtenerSubastasAsync()
        {
            return await _subastaRepositorio.ObtenerTodosAsync();
        }

        public async Task<Subasta> ObtenerSubastaAsync(int id)
        {
            return await _subastaRepositorio.ObtenerPorIdAsync(id);
        }

        public async Task CrearSubastaAsync(Subasta subasta)
        {
            await _subastaRepositorio.InsertarAsync(subasta);
        }

        public async Task ActualizarSubastaAsync(Subasta subasta)
        {
            await _subastaRepositorio.ActualizarAsync(subasta);
        }

        public async Task EliminarSubastaAsync(int id)
        {
            var subasta = await ObtenerSubastaAsync(id);
            if (subasta != null)
            {
                await _subastaRepositorio.EliminarAsync(subasta);
            }
        }
    }
}