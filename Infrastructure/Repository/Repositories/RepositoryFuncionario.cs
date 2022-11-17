using Domain.Interfaces;
using Entities.Entities.Atendimentos;
using Entities.Entities.Cargos;
using Entities.Entities.Empresas;
using Entities.Entities.Exames;
using Entities.Entities.Funcionarios;
using Entities.Entities.Riscos;
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

        public async Task<List<FuncionarioAtendimento>> FuncionarioAtendimento(int? idAtendimento, int? idFuncionario, int? idEmpresa)
        {
            using var banco = new ContextBase(_OptionsBuilder);

            var ats = await(from at in banco.Atendimento where at.IdAtendimento == idAtendimento select new Atendimento { IdAtendimento = at.IdAtendimento }).AsNoTracking().ToListAsync();


            return await(from a in banco.Atendimento
                         join af in banco.AtendimentoFuncionario on a.IdAtendimento equals af.IdAtendimento
                         join f in banco.Funcionario on af.IdFuncionario equals f.IdFuncionario
                         join e in banco.Empresa on f.IdEmpresa equals e.IdEmpresa
                         join ae in banco.AtendimentoEmpresa on e.IdEmpresa equals ae.IdEmpresa
                         join u in banco.Unidade on e.IdEmpresa equals u.IdEmpresa
                         join c in banco.Cargo on f.IdCargo equals c.IdCargo
                         join s in banco.Setor on f.IdSetor equals s.IdSetor
                         join aex in banco.AtendimentoExames on a.IdAtendimento equals aex.IdAtendimento
                         join ex in banco.Exame on aex.IdExame equals ex.IdExame
                         join ar in banco.AtendimentoRiscos on a.IdAtendimento equals ar.IdAtendimento
                         join r in banco.Risco on ar.IdRisco equals r.IdRisco
                         where idEmpresa.Equals(f.IdEmpresa) || idFuncionario.Equals(f.IdFuncionario) || idAtendimento.Equals(a.IdAtendimento)
                         select new FuncionarioAtendimento
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
                             EmpresaFun = new Empresa { IdEmpresa = e.IdEmpresa, RazaoSocialEmpresa = e.RazaoSocialEmpresa },
                             UnidadeFun = new Unidade { IdUnidade = u.IdUnidade, RazaoSocialUnidade = u.RazaoSocialUnidade },
                             AtendimentoFun = new Atendimento 
                                                {
                                                    IdAtendimento = a.IdAtendimento, 
                                                    DataAtendimento = a.DataAtendimento,
                                                    DataAgendamentoAtendimento = a.DataAgendamentoAtendimento,
                                                    HoraInicialAtendimento = a.HoraInicialAtendimento,
                                                    HoraFinalAtendimento = a.HoraFinalAtendimento,
                                                    HoraAgendadaAtendimento = a.HoraInicialAtendimento,
                                                    CompromissoAtendimento = a.CompromissoAtendimento,
                                                    TipoCompromissoAtendimento = a.TipoCompromissoAtendimento,
                                                    RazaoSocialAtendimento = a.RazaoSocialAtendimento,
                                                    FuncionarioAtendimento = a.FuncionarioAtendimento,
                                                    RGAtendimento = a.RGAtendimento,
                                                    CPFAtendimento = a.CPFAtendimento,
                                                    MatriculaAtendimento = a.MatriculaAtendimento,
                                                    UnidadeAtendimento = a.UnidadeAtendimento,
                                                    SetorAtendimento = a.SetorAtendimento,
                                                    CargoAtendimento = a.CargoAtendimento,
                                                    AtendimentoAtendimento = a.AtendimentoAtendimento,
                                                    IdUsuarioAtendimento = a.IdUsuarioAtendimento,
                                                    StatusAtendimento = a.StatusAtendimento,
                                                    DataCadastro = a.DataCadastro,
                                                    DataAlteracao = a.DataAlteracao
                                                 },
                             ExameFun = new List<Exame>{ new Exame { IdExame = aex.IdExame, NomeExame = ex.NomeExame } },
                             RiscoFun = new List<Risco> { new Risco { IdRisco = ar.IdRisco, NomeRisco = r.NomeRisco } }

                         }).Distinct().AsNoTracking().ToListAsync();
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
