using Domain.Interfaces;
using Entities.Entities.Funcionarios;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryFuncionario : RepositoryGenerics<Funcionario>, IFuncionario
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryFuncionario()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Funcionario>> ListarFuncionario(Expression<Func<Funcionario, bool>> exFuncionario)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.Funcionario.Where(exFuncionario).AsNoTracking().ToListAsync();
            }
        }
    }
}
