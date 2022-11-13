using Domain.Interfaces;
using Entities.Entities.Empresas;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryUsuarioEmpresa : RepositoryGenerics<UsuarioEmpresa>, IUsuarioEmpresa
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder; 
        
        public RepositoryUsuarioEmpresa()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }
    }
}
