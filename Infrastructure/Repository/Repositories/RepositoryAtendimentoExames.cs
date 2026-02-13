using Domain.Interfaces;
using Entities.Entities.Exames;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryAtendimentoExames : RepositoryGenerics<AtendimentoExames>, IAtendimentoExames
    {
        public RepositoryAtendimentoExames(DbContextOptions<ContextBase> optionsBuilder) : base(optionsBuilder)
        {
        }
    }
}
