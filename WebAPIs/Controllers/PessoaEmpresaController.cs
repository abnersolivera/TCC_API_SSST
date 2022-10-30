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

        [Authorize]
        [Produces("application/json")]
        [HttpPatch("/api/PessoaEmpresa/Update")]
        public async Task<List<Notifies>> Update(PessoaEmpresaViewModel pessoaEmpresa)
        {
            var pessoaEmpresaMap = _IMapper.Map<PessoaEmpresa>(pessoaEmpresa);
            await _IPessoaEmpresa.Update(pessoaEmpresaMap);
            return pessoaEmpresaMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpDelete("/api/PessoaEmpresa/Delete")]
        public async Task<List<Notifies>> Delete(PessoaEmpresaViewModel pessoaEmpresa)
        {
            var pessoaEmpresaMap = _IMapper.Map<PessoaEmpresa>(pessoaEmpresa);
            await _IPessoaEmpresa.Delete(pessoaEmpresaMap);
            return pessoaEmpresaMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/PessoaEmpresa/GetEntityById")]
        public async Task<PessoaEmpresaViewModel> GetEntityById(PessoaEmpresaViewModel pessoaEmpresa)
        {
            var pessoaEmpresas = await _IPessoaEmpresa.GetEntityById(pessoaEmpresa.IdPessoaEmpresa);
            var pessoaEmpresaMap = _IMapper.Map<PessoaEmpresaViewModel>(pessoaEmpresas);
            return pessoaEmpresaMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/PessoaEmpresa/List")]
        public async Task<List<PessoaEmpresaViewModel>> List()
        {
            var pessoaEmpresa = await _IPessoaEmpresa.List();
            var pessoaEmpresaMap = _IMapper.Map<List<PessoaEmpresaViewModel>>(pessoaEmpresa);
            return pessoaEmpresaMap;
        }
    }
}
