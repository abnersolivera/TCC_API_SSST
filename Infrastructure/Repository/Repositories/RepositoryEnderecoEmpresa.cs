using Domain.Interfaces;
using Entities.Entities.Endereco;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryEnderecoEmpresa : RepositoryGenerics<EnderecoEmpresa>, IEnderecoEmpresa
    {
        public RepositoryEnderecoEmpresa(DbContextOptions<ContextBase> optionsBuilder) : base(optionsBuilder)
        {
        }
    }
}
