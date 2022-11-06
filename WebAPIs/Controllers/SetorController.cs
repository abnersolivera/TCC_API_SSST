using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Services;
using Entities.Entities;
using Entities.Entities.Setores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetorController : ControllerBase
    {
        private readonly IMapper _Imapper;
        private readonly ISetor _ISetor;
        private readonly IServiceSetor _IServiceSetor;

        public SetorController(IMapper imapper, ISetor iSetor, IServiceSetor iServiceSetor)
        {
            _Imapper = imapper;
            _ISetor = iSetor;
            _IServiceSetor = iServiceSetor;
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
        [HttpPost("/api/Setor/Add")]
        public async Task<List<Notifies>> Add(SetorViewModel setor)
        {
            var setorMap = _Imapper.Map<Setor>(setor);
            await _IServiceSetor.Adicionar(setorMap);
            return setorMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPatch("/api/Setor/Update")]
        public async Task<List<Notifies>> Update(SetorViewModel setor)
        {
            var setorMap = _Imapper.Map<Setor>(setor);
            await _IServiceSetor.Atualizar(setorMap);
            return setorMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpDelete("/api/Setor/Delete")]
        public async Task<List<Notifies>> Delete(int setor)
        {
            var setorMap = _Imapper.Map<Setor>(setor);
            await _ISetor.Delete(setorMap);
            return setorMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Setor/GetEntityById")]
        public async Task<SetorViewModel> GetEntityById([FromQuery] SetorIdViewModel setor)
        {
            var setores = await _ISetor.GetEntityById(setor.IdSetor);
            var setorMap = _Imapper.Map<SetorViewModel>(setores);
            return setorMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Setor/List")]
        public async Task<List<SetorViewModel>> List()
        {
            var setor = await _ISetor.List();
            var setorMap = _Imapper.Map<List<SetorViewModel>>(setor);
            return setorMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Setor/ListarSetorAtivos")]
        public async Task<List<SetorViewModel>> ListarSetorAtivos()
        {
            var setor = await _IServiceSetor.ListarSetorAtivo();
            var setorMap = _Imapper.Map<List<SetorViewModel>>(setor);
            return setorMap;
        }
    }
}
