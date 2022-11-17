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
    }
}
