using Domain.Interfaces;
using Entities.Entities.Empresas;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryEmpresa : RepositoryGenerics<Empresa>, IEmpresa
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryEmpresa()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Empresa>> ListarEmpresa(Expression<Func<Empresa, bool>> exEmpresa)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.Empresa.Where(exEmpresa).AsNoTracking().ToListAsync();
            }
        }
    }
}
