using Domain.Interfaces;
using Entities.Entities.Riscos;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryFuncionarioRisco : RepositoryGenerics<FuncionarioRisco>, IFuncionarioRisco
    {
        public RepositoryFuncionarioRisco(DbContextOptions<ContextBase> optionsBuilder) : base(optionsBuilder)
        {
        }
    }
}
