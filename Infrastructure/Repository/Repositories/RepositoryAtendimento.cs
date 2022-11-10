using Domain.Interfaces;
using Entities.Entities;
using Entities.Entities.Atendimentos;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryAtendimento : RepositoryGenerics<Atendimento>, IAtendimento
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryAtendimento()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<ApplicationUser> ListarUserById(string Id)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.Set<ApplicationUser>().FindAsync(Id);

            }
        }
    }
}
