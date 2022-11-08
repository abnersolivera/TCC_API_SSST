using AutoMapper;
using Domain.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;
using Entities.Entities.Endereco;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoUnidadeController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly IEnderecoUnidade _IEnderecoUnidade;

        public EnderecoUnidadeController(IMapper iMapper, IEnderecoUnidade iEnderecoUnidade)
        {
            _IMapper = iMapper;
            _IEnderecoUnidade = iEnderecoUnidade;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/EnderecoUnidade/Add")]
        public async Task<List<Notifies>> Add(EnderecoUnidadeViewModel enderecoUnidade)
        {
            var enderecoUnidadeMap = _IMapper.Map<EnderecoUnidade>(enderecoUnidade);
            await _IEnderecoUnidade.Add(enderecoUnidadeMap);
            return enderecoUnidadeMap.Notitycoes;
        }
    }
}
