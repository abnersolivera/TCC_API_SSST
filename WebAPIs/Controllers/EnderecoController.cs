using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;
using Entities.Entities.Endereco;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IMapper _Imapper;

        private readonly IEndereco _IEndereco;
        private readonly IServiceEndereco _IServiceEndereco;

        public EnderecoController(IMapper imapper, IEndereco iEndereco, IServiceEndereco iServiceEndereco)
        {
            _Imapper = imapper;
            _IEndereco = iEndereco;
            _IServiceEndereco = iServiceEndereco;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/Endereco/Add")]
        public async Task<List<Notifies>> Add(EnderecoViewModel endereco)
        {
            var enderecoMap = _Imapper.Map<Endereco>(endereco);
            await _IServiceEndereco.Adicionar(enderecoMap);
            return enderecoMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPatch("/api/Endereco/Update")]
        public async Task<List<Notifies>> Update(EnderecoViewModel endereco)
        {
            var enderecoMap = _Imapper.Map<Endereco>(endereco);
            await _IServiceEndereco.Atualizar(enderecoMap);
            return enderecoMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpDelete("/api/Endereco/Delete")]
        public async Task<List<Notifies>> Delete(int endereco)
        {
            var enderecoMap = _Imapper.Map<Endereco>(endereco);
            await _IEndereco.Delete(enderecoMap);
            return enderecoMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Endereco/GetEntityById")]
        public async Task<EnderecoViewModel> GetEntityById([FromQuery] EnderecoIdViewModel endereco)
        {
            var enderecos = await _IEndereco.GetEntityById(endereco.IdEndereco);
            var enderecoMap = _Imapper.Map<EnderecoViewModel>(enderecos);
            return enderecoMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Endereco/List")]
        public async Task<List<EnderecoViewModel>> List()
        {
            var endereco = await _IEndereco.List();
            var enderecoMap = _Imapper.Map<List<EnderecoViewModel>>(endereco);
            return enderecoMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Endereco/ListarEnderecoAtivos")]
        public async Task<List<EnderecoViewModel>> ListarEnderecoAtivos()
        {
            var endereco = await _IServiceEndereco.ListarEnderecoAtivas();
            var enderecoMap = _Imapper.Map<List<EnderecoViewModel>>(endereco);
            return enderecoMap;
        }
    }
}
