using Domain.Interfaces.InterfaceServices;
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
    public class RepositoryPrestadorEmpresa : RepositoryGenerics<PrestadorEmpresa>, IPrestadorEmpresa
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder; 
        
        public RepositoryPrestadorEmpresa()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }
    }
}
