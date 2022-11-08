using AutoMapper;
using Domain.Interfaces;
using Entities.Entities.Endereco;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoEmpresaController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly IEnderecoEmpresa _IEnderecoEmpresa;

        public EnderecoEmpresaController(IMapper iMapper, IEnderecoEmpresa iEnderecoEmpresa)
        {
            _IMapper = iMapper;
            _IEnderecoEmpresa = iEnderecoEmpresa;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/EnderecoEmpresa/Add")]
        public async Task<List<Notifies>> Add(EnderecoEmpresaViewModel enderecoEmpresa)
        {
            var enderecoEmpresaMap = _IMapper.Map<EnderecoEmpresa>(enderecoEmpresa);
            await _IEnderecoEmpresa.Add(enderecoEmpresaMap);
            return enderecoEmpresaMap.Notitycoes;
        }
    }
}
