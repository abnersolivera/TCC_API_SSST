using Domain.Interfaces;
using Entities.Entities.Exames;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryExame : RepositoryGenerics<Exame>, IExame
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryExame()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Exame>> ListarExame(Expression<Func<Exame, bool>> exExame)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.Exame.Where(exExame).AsNoTracking().ToListAsync();
            }
        }
    }
}
