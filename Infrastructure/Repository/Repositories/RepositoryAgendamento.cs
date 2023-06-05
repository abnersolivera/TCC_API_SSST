using Domain.Interfaces;
using Entities.Entities.Atendimentos;
using Entities.Entities.Cargos;
using Entities.Entities.Empresas;
using Entities.Entities.Funcionarios;
using Entities.Entities.Setores;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryAgendamento : RepositoryGenerics<Agendamento>, IAgendamento
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryAgendamento()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<int> CountAtendimento()
        {
            using var banco = new ContextBase(_OptionsBuilder);

            return await (from a in banco.Agendamento select a).CountAsync();
        }

        public async Task<List<AgendamentoFuncionario>> ListarAgendamentoFuncionario(int? idFuncionario, int? idEmpresa, int? idAgendamento)
        {
            using var banco = new ContextBase(_OptionsBuilder);

            return await (from a in banco.Agendamento
                               join f in banco.Funcionario on a.IdFuncionario equals f.IdFuncionario
                               join c in banco.Cargo on f.IdCargo equals c.IdCargo
                               join s in banco.Setor on f.IdSetor equals s.IdSetor
                               join e in banco.Empresa on f.IdEmpresa equals e.IdEmpresa
                               join u in banco.Unidade on e.IdEmpresa equals u.IdEmpresa
                               where (idFuncionario.Equals(f.IdFuncionario) || idEmpresa.Equals(e.IdEmpresa)) & idAgendamento.Equals(a.IdAgendamento)
                          select new AgendamentoFuncionario
                               {
                                   Agendamento = new Agendamento
                                   {
                                       DataAgendamento = a.DataAgendamento,
                                       FuncionarioAgendamento = a.FuncionarioAgendamento,
                                       DataAlteracao= a.DataAlteracao,
                                       DataCadastro= a.DataCadastro,
                                       TipoCompromissoAgendamento= a.TipoCompromissoAgendamento,
                                       CompromissoAgendamento = a.CompromissoAgendamento,
                                       HoraAgendada = a.HoraAgendada,
                                       IdAgendamento = a.IdAgendamento,
                                       IdEmpresa= a.IdEmpresa,
                                       IdFuncionario = a.IdFuncionario
                                   },
                                   Funcionario = new Funcionario
                                   {
                                       IdFuncionario= f.IdFuncionario,
                                       NomeFuncionario= f.NomeFuncionario
                                   },
                                   CargoFun = new Cargo
                                   {
                                       IdCargo= c.IdCargo,
                                       NomeCargo= c.NomeCargo
                                   },
                                   SetorFun = new Setor 
                                   {
                                       IdSetor = s.IdSetor,
                                       NomeSetor= s.NomeSetor
                                   },
                                   EmpresaFun = new Empresa
                                   {
                                       IdEmpresa = e.IdEmpresa,
                                       RazaoSocialEmpresa = e.RazaoSocialEmpresa,
                                       CnpjEmpresa = e.CnpjEmpresa
                                   },
                                   UnidadeFun = new Unidade
                                   {
                                       IdUnidade = u.IdUnidade,
                                       RazaoSocialUnidade = u.RazaoSocialUnidade,
                                       CnpjUnidade = u.CnpjUnidade
                                   }
                               }).AsNoTracking().ToListAsync();
        }
    }
}
