using Domain.Interfaces;
using Entities.Entities.Cargos;
using Entities.Entities.Setores;
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
    public class RepositoryCargo : RepositoryGenerics<Cargo>, ICargo
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryCargo()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Cargo>> ListarCargo(Expression<Func<Cargo, bool>> exCargo)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.Cargo.Where(exCargo).AsNoTracking().ToListAsync();
            }
        }
    }
}
