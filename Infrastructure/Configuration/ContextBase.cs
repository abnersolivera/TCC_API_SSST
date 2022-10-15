﻿using Entities.Entities;
using Entities.Entities.Pessoas;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options){}

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
