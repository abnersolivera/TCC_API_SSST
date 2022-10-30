using AutoMapper;
using Domain.Interfaces;
using Entities.Entities;
using Entities.Entities.Empresas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioEmpresaController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly IUsuarioEmpresa _IUsuarioEmpresa;

        public UsuarioEmpresaController(IMapper iMapper, IUsuarioEmpresa iUsuarioEmpresa)
        {
            _IMapper = iMapper;
            _IUsuarioEmpresa = iUsuarioEmpresa;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/UsuarioEmpresa/Add")]
        public async Task<List<Notifies>> Add(UsuarioEmpresaViewModel usuarioEmpresa)
        {
            var usuarioEmpresaMap = _IMapper.Map<UsuarioEmpresa>(usuarioEmpresa);
            await _IUsuarioEmpresa.Add(usuarioEmpresaMap);
            return usuarioEmpresaMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPatch("/api/UsuarioEmpresa/Update")]
        public async Task<List<Notifies>> Update(UsuarioEmpresaViewModel usuarioEmpresa)
        {
            var usuarioEmpresaMap = _IMapper.Map<UsuarioEmpresa>(usuarioEmpresa);
            await _IUsuarioEmpresa.Update(usuarioEmpresaMap);
            return usuarioEmpresaMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpDelete("/api/UsuarioEmpresa/Delete")]
        public async Task<List<Notifies>> Delete(UsuarioEmpresaViewModel usuarioEmpresa)
        {
            var usuarioEmpresaMap = _IMapper.Map<UsuarioEmpresa>(usuarioEmpresa);
            await _IUsuarioEmpresa.Delete(usuarioEmpresaMap);
            return usuarioEmpresaMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/UsuarioEmpresa/GetEntityById")]
        public async Task<UsuarioEmpresaViewModel> GetEntityById(UsuarioEmpresaViewModel usuarioEmpresa)
        {
            var usuarioEmpresas = await _IUsuarioEmpresa.GetEntityById(usuarioEmpresa.IdUsuarioEmpresa);
            var usuarioEmpresaMap = _IMapper.Map<UsuarioEmpresaViewModel>(usuarioEmpresas);
            return usuarioEmpresaMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/UsuarioEmpresa/List")]
        public async Task<List<UsuarioEmpresaViewModel>> List()
        {
            var usuarioEmpresa = await _IUsuarioEmpresa.List();
            var usuarioEmpresaMap = _IMapper.Map<List<UsuarioEmpresaViewModel>>(usuarioEmpresa);
            return usuarioEmpresaMap;
        }
    }
}
