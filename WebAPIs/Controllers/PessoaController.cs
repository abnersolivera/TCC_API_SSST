using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using Entities.Entities.Pessoas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IMapper _Imapper;

        private readonly IPessoa _Ipessoa;
        private readonly IServicePessoa _ServicePessoa;

        public PessoaController(IMapper imapper, IPessoa ipessoa, IServicePessoa servicePessoa)
        {
            _Imapper = imapper;
            _Ipessoa = ipessoa;
            _ServicePessoa = servicePessoa;
        }

        private async Task<string> RetornaIdUsuarioLogado()
        {
            if(User != null)
            {
                var idUsuario = User.FindFirst("idUsuario");
                return idUsuario.Value;
            }

            return string.Empty;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/Add")]
        public async Task<List<Notifies>> Add(PessoaViewModel pessoa)
        { 
            var pessoaMap = _Imapper.Map<Pessoa>(pessoa);
            await _ServicePessoa.Adicionar(pessoaMap);
            return pessoaMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/Update")]
        public async Task<List<Notifies>> Update(PessoaViewModel pessoa)
        {
            var pessoaMap = _Imapper.Map<Pessoa>(pessoa);            
            await _ServicePessoa.Atualizar(pessoaMap);
            return pessoaMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/Delete")]
        public async Task<List<Notifies>> Delete(PessoaViewModel pessoa)
        {
            var pessoaMap = _Imapper.Map<Pessoa>(pessoa);
            await _Ipessoa.Delete(pessoaMap);
            return pessoaMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/GetEntityById")]
        public async Task<PessoaViewModel> GetEntityById(Pessoa pessoa)
        {
            pessoa = await _Ipessoa.GetEntityById(pessoa.IdPessoas);
            var pessoaMap = _Imapper.Map<PessoaViewModel>(pessoa);
            return pessoaMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/List")]
        public async Task<List<PessoaViewModel>> List()
        {
            var pessoa = await _Ipessoa.List();
            var pessoaMap = _Imapper.Map<List<PessoaViewModel>>(pessoa);
            return pessoaMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/ListarPessoasAtivas")]
        public async Task<List<PessoaViewModel>> ListarMessageAtivas()
        {
            var pessoa = await _ServicePessoa.ListarPessoaAtivas();
            var pessoaMap = _Imapper.Map<List<PessoaViewModel>>(pessoa);
            return pessoaMap;
        }
    }
}
