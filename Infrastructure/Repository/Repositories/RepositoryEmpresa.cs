using Domain.Interfaces;
using Entities.Entities.Empresas;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryEmpresa : RepositoryGenerics<Empresa>, IEmpresa
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryEmpresa()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Empresa>> ListarEmpresa(Expression<Func<Empresa, bool>> exEmpresa)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.Empresa.Where(exEmpresa).AsNoTracking().ToListAsync();
            }
        }

        public async Task<List<Empresa>> ListarNomeEmpresa(string? nome, int? id, string? cnpj, string? cpf)
        {
            using var banco = new ContextBase(_OptionsBuilder);

            return await (from e in banco.Empresa
                          where e.RazaoSocialEmpresa.Contains(nome) || e.IdEmpresa.Equals(id) || e.CnpjEmpresa.Contains(cnpj) || e.CpfEmpresa.Contains(cpf)
                          select new Empresa
                          {
                              IdEmpresa= e.IdEmpresa,
                              RazaoSocialEmpresa = e.RazaoSocialEmpresa,
                              NomeAbreviadoEmpresa = e.NomeAbreviadoEmpresa,
                              CnpjEmpresa= e.CnpjEmpresa,
                              CpfEmpresa= e.CpfEmpresa,
                              DataAlteracao= e.DataAlteracao,
                              DataCadastro= e.DataCadastro,
                              DataContratoEmpresa= e.DataContratoEmpresa,
                              InscricaoEstadualEmpresa = e.InscricaoEstadualEmpresa,
                              InscricaoMunicipalEmpresa=e.InscricaoMunicipalEmpresa,
                              NumeroContratoEmpresa = e.NumeroContratoEmpresa,
                              SituacaoEmpresa = e.SituacaoEmpresa,
                              TipoCliente = e.TipoCliente,
                              TipoPessoa= e.TipoPessoa,
                          }).AsNoTracking().ToListAsync();
        }
    }
}
