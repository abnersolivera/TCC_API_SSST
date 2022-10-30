using Domain.Interfaces;
using Entities.Entities.Empresas;
using Infrastructure.Repository.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryPessoaEmpresa : RepositoryGenerics<PessoaEmpresa>, IPessoaEmpresa
    {
    }
}
