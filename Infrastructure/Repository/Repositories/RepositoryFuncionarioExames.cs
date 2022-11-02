using Domain.Interfaces;
using Entities.Entities.Exames;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryFuncionarioExames : RepositoryGenerics<FuncionarioExames>, IFuncionarioExames
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryFuncionarioExames()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }
    }
}
