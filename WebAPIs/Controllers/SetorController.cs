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
        public async Task<List<Notifies>> Delete([FromQuery] SetorIdViewModel setor)
        {
            var setorMap = _Imapper.Map<Setor>(setor);
            await _ISetor.Delete(setorMap);
            return setorMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Setor/GetEntityById")]
        public async Task<SetorDTO> GetEntityById([FromQuery] SetorIdViewModel setor)
        {
            var setores = await _ISetor.GetEntityById(setor.IdSetor);
            var setorMap = _Imapper.Map<SetorDTO>(setores);
            return setorMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Setor/List")]
        public async Task<List<SetorDTO>> List()
        {
            var setor = await _ISetor.List();
            var setorMap = _Imapper.Map<List<SetorDTO>>(setor);
            return setorMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Setor/ListarSetorAtivos")]
        public async Task<List<SetorDTO>> ListarSetorAtivos()
        {
            var setor = await _IServiceSetor.ListarSetorAtivo();
            var setorMap = _Imapper.Map<List<SetorDTO>>(setor);
            return setorMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Setor/ListarSetorEmpresa")]
        public async Task<List<SetorDTO>> ListarSetorEmpresa([FromQuery] int idEmpresa)
        {
            var setor = await _IServiceSetor.ListarSetorEmpresa(idEmpresa);
            var setorMap = _Imapper.Map<List<SetorDTO>>(setor);
            return setorMap;
        }
    }
}
