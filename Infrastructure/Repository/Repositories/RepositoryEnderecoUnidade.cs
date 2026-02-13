using Domain.Interfaces;
using Entities.Entities.Endereco;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryEnderecoUnidade : RepositoryGenerics<EnderecoUnidade>, IEnderecoUnidade
    {
        public RepositoryEnderecoUnidade(DbContextOptions<ContextBase> optionsBuilder) : base(optionsBuilder)
        {
        }

    }
}
