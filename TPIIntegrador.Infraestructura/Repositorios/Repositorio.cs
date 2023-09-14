using Microsoft.EntityFrameworkCore;
using TPIIntegrador.Dominio.Entidades;
using TPIIntegrador.Dominio.Respositorios;
using TPIIntegrador.Infraestructura.Contextos;

namespace TPIIntegrador.Infraestructura.Repositorios
{
    public class Repositorio<T> : IRepositorio<T> where T : Entidad
    {
        private readonly AplicacionContext _contexto;
        private readonly DbSet<T> _dbSet;

        // Inyectar la dependencia del contexto de datos
        public Repositorio(AplicacionContext context)
        {
            _contexto = context;
            _dbSet = context.Set<T>();
        }

        public async Task InsertarAsync(T entidad)
        {
            await _dbSet.AddAsync(entidad);
            await GuardarAsync();
        }

        public async Task ActualizarAsync(T entidad)
        {
            _dbSet.Update(entidad);
            await GuardarAsync();
        }

        public async Task EliminarAsync(T entidad)
        {
            _dbSet.Remove(entidad);
            await GuardarAsync();
        }

        public async Task<T> ObtenerPorIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IQueryable<T>> ObtenerTodosAsync()
        {
            return await Task.FromResult(_dbSet.AsQueryable());
        }

        public async Task GuardarAsync()
        {
            await _contexto.SaveChangesAsync();
        }
    }
}
