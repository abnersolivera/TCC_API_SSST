using Domain.Interfaces;
using Entities.Entities;
using Entities.Entities.Atendimentos;
using Entities.Entities.Empresas;
using Entities.Entities.Exames;
using Entities.Entities.Funcionarios;
using Entities.Entities.Riscos;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Repositories
{

    public class RepositoryAtendimento : RepositoryGenerics<Atendimento>, IAtendimento
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryAtendimento()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<object> CountAtendimentoExames()
        {
            using var banco = new ContextBase(_OptionsBuilder);

            #region QueryExame
            var queryExame = await (from ae in banco.AtendimentoExames
                                    join e in banco.Exame on ae.IdExame equals e.IdExame
                                    select new Exame { IdExame = e.IdExame, NomeExame = e.NomeExame }).AsNoTracking().ToListAsync();
            #endregion

            var count = queryExame.GroupBy(e => e.NomeExame).Select(g => g.Select(g => new { Noma = g.NomeExame, Count = g.NomeExame.Count() }).Distinct()).ToList();
  
            return count;
        }

        public async Task<Atendimento> Atendimentos(Atendimento atendimento, Empresa empresa, Funcionario funcionario, List<Risco> risco, List<Exame> exame)
        {

            using (var banco = new ContextBase(_OptionsBuilder))
            {

                await banco.Set<Atendimento>().AddAsync(atendimento);
                await banco.SaveChangesAsync();


                var dadosEmpresa = new AtendimentoEmpresa();
                dadosEmpresa.IdAtendimento = atendimento.IdAtendimento;
                dadosEmpresa.IdEmpresa = empresa.IdEmpresa;
                await banco.Set<AtendimentoEmpresa>().AddAsync(dadosEmpresa);
                await banco.SaveChangesAsync();


                var dadosFuncionario = new AtendimentoFuncionario();
                dadosFuncionario.IdAtendimento = atendimento.IdAtendimento;
                dadosFuncionario.IdFuncionario = funcionario.IdFuncionario;
                await banco.Set<AtendimentoFuncionario>().AddAsync(dadosFuncionario);
                await banco.SaveChangesAsync();

                foreach (var item in risco)
                {
                    var dados = new AtendimentoRiscos();
                    dados.IdAtendimento = atendimento.IdAtendimento;
                    dados.IdRisco = item.IdRisco;
                    await banco.Set<AtendimentoRiscos>().AddAsync(dados);
                    await banco.SaveChangesAsync();
                }


                foreach (var item in exame)
                {
                    var dadosExames = new AtendimentoExames();
                    dadosExames.IdAtendimento = atendimento.IdAtendimento;
                    dadosExames.IdExame = item.IdExame;
                    await banco.Set<AtendimentoExames>().AddAsync(dadosExames);
                    await banco.SaveChangesAsync();
                }
                return atendimento;
            }
        }

        public async Task<Atendimento> ListarUserById(string Id)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.Set<Atendimento>().FindAsync(Id);

            }
        }
        
    }
}
