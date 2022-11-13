using Domain.Interfaces;
using Entities.Entities.Empresas;
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
    public class RepositoryPessoaEmpresa : RepositoryGenerics<PessoaEmpresa>, IPessoaEmpresa
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryPessoaEmpresa()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }
    }
}
