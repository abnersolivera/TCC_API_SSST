using Domain.Interfaces;
using Entities.Entities.Riscos;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryAtendimentoRiscos : RepositoryGenerics<AtendimentoRiscos>, IAtendimentoRiscos
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryAtendimentoRiscos()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }
    }
}
