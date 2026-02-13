using Domain.Interfaces;
using Entities.Entities.Atendimentos;
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
        public RepositoryAgendamento(DbContextOptions<ContextBase> optionsBuilder) : base(optionsBuilder)
        {
        }

        public async Task<int> CountAtendimento()
        {
            using var banco = new ContextBase(_OptionsBuilder);

            return await (from a in banco.Agendamento select a).CountAsync();
        }
    }
}
