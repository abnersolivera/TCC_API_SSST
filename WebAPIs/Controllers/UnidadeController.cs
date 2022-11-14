using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Services;
using Entities.Entities;
using Entities.Entities.Empresas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadeController : ControllerBase
    {
        private readonly IMapper _IMapper;

        private readonly IUnidade _IUnidade;
        private readonly IServiceUnidade _IServiceUnidade;

        public UnidadeController(IMapper iMapper, IUnidade iUnidade, IServiceUnidade iServiceUnidade)
        {
            _IMapper = iMapper;
            _IUnidade = iUnidade;
            _IServiceUnidade = iServiceUnidade;
        }

        private async Task<string> RetornaIdUsuarioLogado()
        {
            if (User != null)
            {
                var idUsuario = User.FindFirst("idUsuario");
                return idUsuario.Value;
            }

            return string.Empty;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/Unidade/Add")]
        public async Task<List<Notifies>> Add(UnidadeViewModel unidade)
        {
            var unidadeMap = _IMapper.Map<Unidade>(unidade);
            await _IServiceUnidade.Adicionar(unidadeMap);
            return unidadeMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPatch("/api/Unidade/Update")]
        public async Task<List<Notifies>> Update(UnidadeViewModel unidade)
        {
            var unidadeMap = _IMapper.Map<Unidade>(unidade);
            await _IServiceUnidade.Atualizar(unidadeMap);
            return unidadeMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpDelete("/api/Unidade/Delete")]
        public async Task<List<Notifies>> Delete([FromQuery] UnidadeIdViewModel unidade)
        {
            var unidadeMap = _IMapper.Map<Unidade>(unidade);
            await _IUnidade.Delete(unidadeMap);
            return unidadeMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Unidade/GetEntityById")]
        public async Task<UnidadeDTO> GetEntityById([FromQuery] UnidadeIdViewModel unidade)
        {
            var unidades = await _IUnidade.GetEntityById(unidade.IdUnidade);
            var unidadeMap = _IMapper.Map<UnidadeDTO>(unidades);
            return unidadeMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Unidade/List")]
        public async Task<List<UnidadeDTO>> List()
        {
            var unidade = await _IUnidade.List();
            var unidadeMap = _IMapper.Map<List<UnidadeDTO>>(unidade);
            return unidadeMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Unidade/ListarUnidadeAtivas")]
        public async Task<List<UnidadeDTO>> ListarUnidadeAtivas()
        {
            var unidade = await _IServiceUnidade.ListarUnidadeAtivas();
            var unidadeMap = _IMapper.Map<List<UnidadeDTO>>(unidade);
            return unidadeMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Unidade/ListarUnidadeEmpresa")]
        public async Task<List<UnidadeDTO>> ListarUnidadeEmpresa([FromQuery] int idEmpresa)
        {
            var unidade = await _IServiceUnidade.ListarUnidadeEmpresa(idEmpresa);
            var unidadeMap = _IMapper.Map<List<UnidadeDTO>>(unidade);
            return unidadeMap;
        }

    }
}
