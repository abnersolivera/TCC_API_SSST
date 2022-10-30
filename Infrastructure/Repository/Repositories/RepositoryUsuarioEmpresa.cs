using Domain.Interfaces;
using Entities.Entities.Empresas;
using Infrastructure.Repository.Generics;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryUsuarioEmpresa : RepositoryGenerics<UsuarioEmpresa>, IUsuarioEmpresa
    {
    }
}
