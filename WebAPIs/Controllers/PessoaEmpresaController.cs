using AutoMapper;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities.Empresas;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;
using Domain.Interfaces;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaEmpresaController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly IPessoaEmpresa _IPessoaEmpresa;

        public PessoaEmpresaController(IMapper iMapper, IPessoaEmpresa iPessoaEmpresa)
        {
            _IMapper = iMapper;
            _IPessoaEmpresa = iPessoaEmpresa;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/PessoaEmpresa/Add")]
        public async Task<List<Notifies>> Add(PessoaEmpresaViewModel pessoaEmpresa)
        {
            var pessoaEmpresaMap = _IMapper.Map<PessoaEmpresa>(pessoaEmpresa);
            await _IPessoaEmpresa.Add(pessoaEmpresaMap);
            return pessoaEmpresaMap.Notitycoes;
        }
    }
}
