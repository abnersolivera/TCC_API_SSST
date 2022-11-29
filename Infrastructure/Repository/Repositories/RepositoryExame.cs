using Domain.Interfaces;
using Entities.Entities;
using Entities.Entities.Exames;
using Entities.Entities.Pessoas;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryExame : RepositoryGenerics<Exame>, IExame
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryExame()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Exame>> ExamesNome(string nome)
        {
            using var banco = new ContextBase(_OptionsBuilder);

            return await (from e in banco.Exame
                          where e.NomeExame.Contains(nome)
                          select e).AsNoTracking().ToListAsync();
        }

        public async Task<ExameDetails> Listar(int curretPage)
        {
            using var banco = new ContextBase(_OptionsBuilder);
            int take = 10;
            int count = await banco.Set<Exame>().CountAsync();
            var details = (new Details { Take = take, PageTotal = count, PageQuantity = Convert.ToInt32(Math.Ceiling(count * 1M / take)), CurretPage = curretPage });
            var query = (await banco.Set<Exame>().Skip(take * (curretPage - 1)).Take(take).ToListAsync());
            var result = new ExameDetails { Exame = query, Details = details };
            return result;
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
