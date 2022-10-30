using Domain.Interfaces;
using Entities.Entities.Riscos;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryRisco : RepositoryGenerics<Risco>, IRisco
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryRisco()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Risco>> ListarRiscos(Expression<Func<Risco, bool>> exRisco)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.Risco.Where(exRisco).AsNoTracking().ToListAsync();
            }
        }
    }
}
