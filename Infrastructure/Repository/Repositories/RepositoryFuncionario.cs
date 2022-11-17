using Domain.Interfaces;
using Entities.Entities.Cargos;
using Entities.Entities.Empresas;
using Entities.Entities.Funcionarios;
using Entities.Entities.Setores;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryFuncionario : RepositoryGenerics<Funcionario>, IFuncionario
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryFuncionario()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Funcionario>> Listar(int id)
        {
            using var banco = new ContextBase(_OptionsBuilder);

            return await (from f in banco.Funcionario
                          join e in banco.Empresa on f.IdEmpresa equals e.IdEmpresa
                          join c in banco.Cargo on f.IdCargo equals c.IdCargo
                          join s in banco.Setor on f.IdSetor equals s.IdSetor
                          where id.Equals(f.IdEmpresa)
                          select new Funcionario
                          {
                              IdFuncionario = f.IdFuncionario,
                              SituacaoFuncionario = f.SituacaoFuncionario,
                              NomeFuncionario = f.NomeFuncionario,
                              DataNascimentoFuncionario = f.DataNascimentoFuncionario,
                              CpfFuncionario = f.CpfFuncionario,
                              RgFuncionario = f.RgFuncionario,
                              PisFuncionario = f.PisFuncionario,
                              TelefoneFuncionario = f.TelefoneFuncionario,
                              EmailFuncionario = f.EmailFuncionario,
                              SexoFuncionario = f.SexoFuncionario,
                              DataCadastro = f.DataCadastro,
                              DataAlteracao = f.DataAlteracao,
                              DataAdmissao = f.DataAdmissao,
                              DataDemissao = f.DataDemissao,
                              IdCargo = f.IdCargo,
                              IdSetor = f.IdSetor,
                              IdEmpresa = f.IdEmpresa

                          }
                         ).AsNoTracking().ToListAsync();
        }

        public async Task<List<FuncionarioEmpresaCargoSetor>> ListarEmpresaCargoSetor(int? id, int? idFuncionario)
        {
            using var banco = new ContextBase(_OptionsBuilder);

            return await (from f in banco.Funcionario
                          join e in banco.Empresa on f.IdEmpresa equals e.IdEmpresa
                          join u in banco.Unidade on e.IdEmpresa equals u.IdEmpresa
                          join c in banco.Cargo on f.IdCargo equals c.IdCargo
                          join s in banco.Setor on f.IdSetor equals s.IdSetor
                          where id.Equals(f.IdEmpresa) || idFuncionario.Equals(f.IdFuncionario)
                          select new FuncionarioEmpresaCargoSetor
                          {
                              IdFuncionario = f.IdFuncionario,
                              SituacaoFuncionario = f.SituacaoFuncionario,
                              NomeFuncionario = f.NomeFuncionario,
                              DataNascimentoFuncionario = f.DataNascimentoFuncionario,
                              CpfFuncionario = f.CpfFuncionario,
                              RgFuncionario = f.RgFuncionario,
                              PisFuncionario = f.PisFuncionario,
                              TelefoneFuncionario = f.TelefoneFuncionario,
                              EmailFuncionario = f.EmailFuncionario,
                              SexoFuncionario = f.SexoFuncionario,
                              DataCadastro = f.DataCadastro,
                              DataAlteracao = f.DataAlteracao,
                              DataAdmissao = f.DataAdmissao,
                              DataDemissao = f.DataDemissao,
                              CargoFun = new Cargo {IdCargo = c.IdCargo, NomeCargo = c.NomeCargo},
                              SetorFun = new Setor {IdSetor = s.IdSetor, NomeSetor = s.NomeSetor},
                              EmpresaFun = new Empresa {IdEmpresa = e.IdEmpresa, RazaoSocialEmpresa = e.RazaoSocialEmpresa},
                              UnidadeFun = new Unidade { IdUnidade = u.IdUnidade, RazaoSocialUnidade = u.RazaoSocialUnidade}
                              

                          }).AsNoTracking().ToListAsync();
        }

        public async Task<List<Funcionario>> ListarFuncionario(Expression<Func<Funcionario, bool>> exFuncionario)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.Funcionario.Where(exFuncionario).AsNoTracking().ToListAsync();
            }
        }

        public async Task<List<FuncionarioEmpresaCargoSetor>> ListarFuncionarioCargoSetor(string nome)
        {
            using var banco = new ContextBase(_OptionsBuilder);

            return await(from f in banco.Funcionario
                         join e in banco.Empresa on f.IdEmpresa equals e.IdEmpresa
                         join c in banco.Cargo on f.IdCargo equals c.IdCargo
                         join s in banco.Setor on f.IdSetor equals s.IdSetor
                         where f.NomeFuncionario!.Contains(nome)
                         select new FuncionarioEmpresaCargoSetor
                         {
                             IdFuncionario = f.IdFuncionario,
                             SituacaoFuncionario = f.SituacaoFuncionario,
                             NomeFuncionario = f.NomeFuncionario,
                             DataNascimentoFuncionario = f.DataNascimentoFuncionario,
                             CpfFuncionario = f.CpfFuncionario,
                             RgFuncionario = f.RgFuncionario,
                             PisFuncionario = f.PisFuncionario,
                             TelefoneFuncionario = f.TelefoneFuncionario,
                             EmailFuncionario = f.EmailFuncionario,
                             SexoFuncionario = f.SexoFuncionario,
                             DataCadastro = f.DataCadastro,
                             DataAlteracao = f.DataAlteracao,
                             DataAdmissao = f.DataAdmissao,
                             DataDemissao = f.DataDemissao,
                             CargoFun = new Cargo { IdCargo = c.IdCargo, NomeCargo = c.NomeCargo },
                             SetorFun = new Setor { IdSetor = s.IdSetor, NomeSetor = s.NomeSetor },
                             EmpresaFun = new Empresa {IdEmpresa = e.IdEmpresa, RazaoSocialEmpresa = e.RazaoSocialEmpresa }

                         }).AsNoTracking().ToListAsync(); 
        }
    }
}
