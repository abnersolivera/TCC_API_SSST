using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using Entities.Entities.Exames;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExameController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly IExame _IExame;
        private readonly IServiceExame _IServiceExame;

        public ExameController(IMapper iMapper, IExame iExame, IServiceExame iServiceExame)
        {
            _IMapper = iMapper;
            _IExame = iExame;
            _IServiceExame = iServiceExame;
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
        [HttpPost("/api/Exame/Add")]
        public async Task<List<Notifies>> Add(ExameViewModel exame)
        {
            var exameMap = _IMapper.Map<Exame>(exame);
            await _IServiceExame.Adicionar(exameMap);
            return exameMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPatch("/api/Exame/Update")]
        public async Task<List<Notifies>> Update(ExameViewModel exame)
        {
            var exameMap = _IMapper.Map<Exame>(exame);
            await _IServiceExame.Atualizar(exameMap);
            return exameMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpDelete("/api/Exame/Delete")]
        public async Task<List<Notifies>> Delete(ExameViewModel exame)
        {
            var exameMap = _IMapper.Map<Exame>(exame);
            await _IExame.Delete(exameMap);
            return exameMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/Exame/GetEntityById")]
        public async Task<ExameViewModel> GetEntityById(ExameViewModel exame)
        {
            var exames = await _IExame.GetEntityById(exame.IdExame);
            var exameMap = _IMapper.Map<ExameViewModel>(exames);
            return exameMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Exame/List")]
        public async Task<List<ExameViewModel>> List()
        {
            var exame = await _IExame.List();
            var exameMap = _IMapper.Map<List<ExameViewModel>>(exame);
            return exameMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Exame/ListarExamesAtivos")]
        public async Task<List<ExameViewModel>> ListarExamesAtivos()
        {
            var exame = await _IServiceExame.ListarExamesAtivo();
            var exameMap = _IMapper.Map<List<ExameViewModel>>(exame);
            return exameMap;
        }
    }
}
