using Domain.Interfaces;
using Entities.Entities.Funcionarios;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryAtendimentoFuncionario : RepositoryGenerics<AtendimentoFuncionario>, IAtendimentoFuncionario
    {
        public RepositoryAtendimentoFuncionario(DbContextOptions<ContextBase> optionsBuilder) : base(optionsBuilder)
        {
        }
    }
}
