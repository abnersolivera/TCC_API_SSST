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
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        

        public RepositoryPessoa()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Pessoa>> ListarPessoa(Expression<Func<Pessoa, bool>> exPessoa)
        {
            

            using (var banco = new ContextBase(_OptionsBuilder))
            {                
                int skip = 0;
                int take = 25;
                int count = await banco.Pessoa.CountAsync();
                return await banco.Pessoa.Where(exPessoa).AsNoTracking().Skip(skip).Take(take).ToListAsync();
            }
        }
    }
}
