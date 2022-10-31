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

        [Authorize]
        [Produces("application/json")]
        [HttpPatch("/api/EnderecoEmpresa/Update")]
        public async Task<List<Notifies>> Update(EnderecoEmpresaViewModel enderecoEmpresa)
        {
            var enderecoEmpresaMap = _IMapper.Map<EnderecoEmpresa>(enderecoEmpresa);
            await _IEnderecoEmpresa.Update(enderecoEmpresaMap);
            return enderecoEmpresaMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpDelete("/api/EnderecoEmpresa/Delete")]
        public async Task<List<Notifies>> Delete(EnderecoEmpresaViewModel enderecoEmpresa)
        {
            var enderecoEmpresaMap = _IMapper.Map<EnderecoEmpresa>(enderecoEmpresa);
            await _IEnderecoEmpresa.Delete(enderecoEmpresaMap);
            return enderecoEmpresaMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/EnderecoEmpresa/GetEntityById")]
        public async Task<EnderecoEmpresaViewModel> GetEntityById(EnderecoEmpresaViewModel enderecoEmpresa)
        {
            var enderecoEmpresas = await _IEnderecoEmpresa.GetEntityById(enderecoEmpresa.IdEnderecoEmpresa);
            var enderecoEmpresaMap = _IMapper.Map<EnderecoEmpresaViewModel>(enderecoEmpresas);
            return enderecoEmpresaMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/EnderecoEmpresa/List")]
        public async Task<List<EnderecoEmpresaViewModel>> List()
        {
            var enderecoEmpresa = await _IEnderecoEmpresa.List();
            var enderecoEmpresaMap = _IMapper.Map<List<EnderecoEmpresaViewModel>>(enderecoEmpresa);
            return enderecoEmpresaMap;
        }
    }
}
