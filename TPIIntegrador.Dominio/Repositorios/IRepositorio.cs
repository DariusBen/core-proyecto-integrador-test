using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TPIIntegrador.Dominio.Respositorios
{
    public interface IRepositorio<T> where T : class
    {
        public Task InsertarAsync(T entidad);
        public Task ActualizarAsync(T entidad);
        public Task EliminarAsync(T entidad);
        public Task<T> ObtenerPorIdAsync(object id);
        public Task<IQueryable<T>> ObtenerTodosAsync();
        public Task GuardarAsync();
    }

}
