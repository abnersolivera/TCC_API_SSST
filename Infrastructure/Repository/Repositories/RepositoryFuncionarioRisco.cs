using Domain.Interfaces;
using Entities.Entities.Riscos;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryFuncionarioRisco : RepositoryGenerics<FuncionarioRisco>, IFuncionarioRisco
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryFuncionarioRisco()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }
    }
}
