using Domain.Interfaces;
using Entities.Entities.Funcionarios;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryAtendimentoFuncionario : RepositoryGenerics<AtendimentoFuncionario>, IAtendimentoFuncionario
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryAtendimentoFuncionario()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }
    }
}
