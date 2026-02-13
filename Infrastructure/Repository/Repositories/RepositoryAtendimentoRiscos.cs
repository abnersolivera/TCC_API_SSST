using Domain.Interfaces;
using Entities.Entities.Riscos;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryAtendimentoRiscos : RepositoryGenerics<AtendimentoRiscos>, IAtendimentoRiscos
    {
        public RepositoryAtendimentoRiscos(DbContextOptions<ContextBase> optionsBuilder) : base(optionsBuilder)
        {
        }
    }
}
