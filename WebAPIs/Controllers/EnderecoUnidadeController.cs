using AutoMapper;
using Domain.Interfaces;
using Entities.Entities.Empresas;
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

        [Authorize]
        [Produces("application/json")]
        [HttpPatch("/api/EnderecoUnidade/Update")]
        public async Task<List<Notifies>> Update(EnderecoUnidadeViewModel enderecoUnidade)
        {
            var enderecoUnidadeMap = _IMapper.Map<EnderecoUnidade>(enderecoUnidade);
            await _IEnderecoUnidade.Update(enderecoUnidadeMap);
            return enderecoUnidadeMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpDelete("/api/EnderecoUnidade/Delete")]
        public async Task<List<Notifies>> Delete(EnderecoUnidadeViewModel enderecoUnidade)
        {
            var enderecoUnidadeMap = _IMapper.Map<EnderecoUnidade>(enderecoUnidade);
            await _IEnderecoUnidade.Delete(enderecoUnidadeMap);
            return enderecoUnidadeMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/EnderecoUnidade/GetEntityById")]
        public async Task<EnderecoUnidadeViewModel> GetEntityById(EnderecoUnidadeViewModel enderecoUnidade)
        {
            var enderecoUnidades = await _IEnderecoUnidade.GetEntityById(enderecoUnidade.IdEnderecoUnidade);
            var enderecoUnidadeMap = _IMapper.Map<EnderecoUnidadeViewModel>(enderecoUnidades);
            return enderecoUnidadeMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/EnderecoUnidade/List")]
        public async Task<List<EnderecoUnidadeViewModel>> List()
        {
            var enderecoUnidade = await _IEnderecoUnidade.List();
            var enderecoUnidadeMap = _IMapper.Map<List<EnderecoUnidadeViewModel>>(enderecoUnidade);
            return enderecoUnidadeMap;
        }
    }
}
