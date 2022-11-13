using Domain.Interfaces;
using Entities.Entities.Endereco;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryEnderecoEmpresa : RepositoryGenerics<EnderecoEmpresa>, IEnderecoEmpresa
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryEnderecoEmpresa()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }
    }
}
