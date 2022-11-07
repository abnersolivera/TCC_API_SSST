using Entities.Entities;
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
using System.Collections.Generic;

namespace Infrastructure.Configuration
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options){}

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

        public string ObterStringConexao()
        {
            return "Data Source=mysqlserver1234567891.database.windows.net;Initial Catalog=mySampleDatabase;Integrated Security=False;User ID=azureuser;Password=123Email@25;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);
            base.OnModelCreating(builder);
        }
    }
}
