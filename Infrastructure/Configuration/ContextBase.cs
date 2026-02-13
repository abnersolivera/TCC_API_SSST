using Entities.Entities;
using Entities.Entities.Atendimentos;
using Entities.Entities.Cargos;
using Entities.Entities.Empresas;
using Entities.Entities.Endereco;
using Entities.Entities.Exames;
using Entities.Entities.Funcionarios;
using Entities.Entities.Pessoas;
using Entities.Entities.Prestadores;
using Entities.Entities.Riscos;
using Entities.Entities.Setores;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration
{
    public class ContextBase(DbContextOptions<ContextBase> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<AtendimentoExames> AtendimentoExames { get; set; }
        public DbSet<AtendimentoFuncionario> AtendimentoFuncionario { get; set; }
        public DbSet<AtendimentoRiscos> AtendimentoRiscos { get; set; }
        public DbSet<AtendimentoEmpresa> AtendimentoEmpresa { get; set; }
        public DbSet<Agendamento> Agendamento { get; set; }
        public DbSet<Atendimento> Atendimento { get; set; }
        public DbSet<FuncionarioRisco> FuncionarioRisco { get; set; }
        public DbSet<FuncionarioExames> FuncionarioExames { get; set; }
        public DbSet<EnderecoUnidade> EnderecoUnidade { get; set; }
        public DbSet<EnderecoEmpresa> EnderecoEmpresa { get; set; }
        public DbSet<PessoaEmpresa> PessoaEmpresa { get; set; }
        public DbSet<PrestadorEmpresa> PrestadorEmpresa { get; set; }
        public DbSet<UsuarioEmpresa> UsuarioEmpresa { get; set; }
        public DbSet<Risco> Risco { get; set; }
        public DbSet<Exame> Exame { get; set; }
        public DbSet<Setor> Setor { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Unidade> Unidade { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Prestador> Prestador { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);
            base.OnModelCreating(builder);
        }
    }
}
