using Domain.Interfaces;
using Entities.Entities.Empresas;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryUnidade : RepositoryGenerics<Unidade>, IUnidade
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryUnidade()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Unidade>> Listar(int id)
        {
            using var banco = new ContextBase(_OptionsBuilder);

            return await (from u in banco.Unidade
                          join e in banco.Empresa on u.IdEmpresa equals e.IdEmpresa
                          where id.Equals(u.IdEmpresa)
                          select new Unidade 
                                     {
                                        IdUnidade = u.IdUnidade,
                                        SituacaoUnidade = u.SituacaoUnidade,
                                        NomeAbreviadoUnidade = u.NomeAbreviadoUnidade,
                                        RazaoSocialUnidade = u.RazaoSocialUnidade,
                                        CnpjUnidade = u.CnpjUnidade,
                                        CpfUnidade = u.CpfUnidade,
                                        InscricaoEstadualUnidade = u.InscricaoEstadualUnidade,
                                        InscricaoMunicipalUnidade = u.InscricaoMunicipalUnidade,
                                        CnoUnidade = u.CnoUnidade,
                                        DataContratoUnidade = u.DataContratoUnidade,
                                        NumeroContratoUnidade = u.NumeroContratoUnidade,
                                        DataCadastro = u.DataCadastro,
                                        DataAlteracao = u.DataAlteracao,
                                        CnaeUnidade = u.CnaeUnidade,
                                        CnaeLivreUnidade = u.CnaeLivreUnidade,
                                        CnaeSecundarioUnidade = u.CnaeSecundarioUnidade,
                                        GrauRiscoUnidade = u.GrauRiscoUnidade,
                                        DescricaoLocalUnidade = u.DescricaoLocalUnidade,
                                        IdEmpresa= u.IdEmpresa,
                                     }
                         ).AsNoTracking().ToListAsync();
        }

        public async Task<List<Unidade>> ListarUnidade(Expression<Func<Unidade, bool>> exUnidade)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.Unidade.Where(exUnidade).AsNoTracking().ToListAsync();
            }
        }
    }
}
