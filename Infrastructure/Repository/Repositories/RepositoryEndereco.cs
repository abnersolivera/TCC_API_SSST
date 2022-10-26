using Domain.Interfaces;
using Entities.Entities.Endereco;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryEndereco : RepositoryGenerics<Endereco>, IEndereco
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryEndereco()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Endereco>> ListarEndereco(Expression<Func<Endereco, bool>> exEndereco)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.Endereco.Where(exEndereco).AsNoTracking().ToListAsync();
            }
        }
    }
}
