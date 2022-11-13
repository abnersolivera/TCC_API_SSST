using Domain.Interfaces;
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
    public class RepositorySetor : RepositoryGenerics<Setor>, ISetor
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorySetor()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Setor>> Listar(int id)
        {
            using var banco = new ContextBase(_OptionsBuilder);

            return await ( from s in banco.Setor
                           join e in banco.Empresa on s.IdEmpresa equals e.IdEmpresa
                           where id.Equals(s.IdEmpresa)
                           select new Setor 
                                      {
                                        IdSetor = s.IdSetor, 
                                        NomeSetor = s.NomeSetor, 
                                        DataCadastro = s.DataCadastro, 
                                        DataAlteracao = s.DataAlteracao, 
                                        IdEmpresa = s.IdEmpresa
                                      }
                         ).AsNoTracking().ToListAsync();
        }

        public async Task<List<Setor>> ListarSetor(Expression<Func<Setor, bool>> exSetor)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.Setor.Where(exSetor).AsNoTracking().ToListAsync();
            }
        }
    }
}
