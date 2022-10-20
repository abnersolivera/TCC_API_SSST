using Domain.Interfaces;
using Entities.Entities.Prestadores;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Repositories
{
    /// <summary>
    /// Entidade Prestador 
    /// </summary>
    public class RepositoryPrestador : RepositoryGenerics<Prestador>, IPrestador
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryPrestador()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Prestador>> ListarPrestador(Expression<Func<Prestador, bool>> exPrestador)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.Prestador.Where(exPrestador).AsNoTracking().ToListAsync();
            }
        }
    }
}
