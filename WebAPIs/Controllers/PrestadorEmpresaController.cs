using AutoMapper;
using Domain.Interfaces;
using Entities.Entities.Empresas;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestadorEmpresaController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly IPrestadorEmpresa _IPrestadorEmpresa;

        public PrestadorEmpresaController(IMapper iMapper, IPrestadorEmpresa iPrestadorEmpresa)
        {
            _IMapper = iMapper;
            _IPrestadorEmpresa = iPrestadorEmpresa;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/PrestadorEmpresa/Add")]
        public async Task<List<Notifies>> Add(PrestadorEmpresaViewModel prestadorEmpresa)
        {
            var prestadorEmpresaMap = _IMapper.Map<PrestadorEmpresa>(prestadorEmpresa);
            await _IPrestadorEmpresa.Add(prestadorEmpresaMap);
            return prestadorEmpresaMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPatch("/api/PrestadorEmpresa/Update")]
        public async Task<List<Notifies>> Update(PrestadorEmpresaViewModel prestadorEmpresa)
        {
            var prestadorEmpresaMap = _IMapper.Map<PrestadorEmpresa>(prestadorEmpresa);
            await _IPrestadorEmpresa.Update(prestadorEmpresaMap);
            return prestadorEmpresaMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpDelete("/api/PrestadorEmpresa/Delete")]
        public async Task<List<Notifies>> Delete(PrestadorEmpresaViewModel prestadorEmpresa)
        {
            var prestadorEmpresaMap = _IMapper.Map<PrestadorEmpresa>(prestadorEmpresa);
            await _IPrestadorEmpresa.Delete(prestadorEmpresaMap);
            return prestadorEmpresaMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/PrestadorEmpresa/GetEntityById")]
        public async Task<PrestadorEmpresaViewModel> GetEntityById(PrestadorEmpresaViewModel prestadorEmpresa)
        {
            var prestadorEmpresas = await _IPrestadorEmpresa.GetEntityById(prestadorEmpresa.IdPrestadorEmpresa);
            var prestadorEmpresaMap = _IMapper.Map<PrestadorEmpresaViewModel>(prestadorEmpresas);
            return prestadorEmpresaMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/PrestadorEmpresa/List")]
        public async Task<List<PrestadorEmpresaViewModel>> List()
        {
            var prestadorEmpresa = await _IPrestadorEmpresa.List();
            var prestadorEmpresaMap = _IMapper.Map<List<PrestadorEmpresaViewModel>>(prestadorEmpresa);
            return prestadorEmpresaMap;
        }
    }
}
