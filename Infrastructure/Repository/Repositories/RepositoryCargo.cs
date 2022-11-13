using Domain.Interfaces;
using Entities.Entities.Cargos;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryCargo : RepositoryGenerics<Cargo>, ICargo
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryCargo()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Cargo>> Listar(int id)
        {
            using var banco = new ContextBase(_OptionsBuilder);

            var query = await ( from c in banco.Cargo
                          join e in banco.Empresa on c.IdEmpresa equals e.IdEmpresa
                          where id.Equals(c.IdEmpresa)
                          select new Cargo {IdCargo = c.IdCargo, NomeCargo = c.NomeCargo, DataCadastro = c.DataCadastro, DataAlteracao = c.DataAlteracao, IdEmpresa = c.IdEmpresa}
                ).ToListAsync();

            return query;
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
