using Domain.Interfaces;
using Entities.Entities.Empresas;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryUnidade : RepositoryGenerics<Unidade>, IUnidade
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryUnidade()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Unidade>> ListarUnidade(Expression<Func<Unidade, bool>> exUnidade)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.Unidade.Where(exUnidade).AsNoTracking().ToListAsync();
            }
        }
    }
}
