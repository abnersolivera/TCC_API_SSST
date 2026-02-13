using Domain.Interfaces;
using Entities.Entities;
using Entities.Entities.Pessoas;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryPessoa : RepositoryGenerics<Pessoa>, IPessoa
    {
        public RepositoryPessoa(DbContextOptions<ContextBase> optionsBuilder) : base(optionsBuilder)
        {
        }

        public async Task<List<Pessoa>> ListarPessoa(Expression<Func<Pessoa, bool>> exPessoa)
        {
            

            using (var banco = new ContextBase(_OptionsBuilder))
            {                

                int count = await banco.Pessoa.CountAsync();
                return await banco.Pessoa.Where(exPessoa).AsNoTracking().ToListAsync();
            }
        }
    }
}
