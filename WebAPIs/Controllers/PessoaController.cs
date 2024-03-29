﻿using AutoMapper;
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
        private readonly IServicePessoa _IServicePessoa;

        public PessoaController(IMapper imapper, IPessoa ipessoa, IServicePessoa iservicePessoa)
        {
            _Imapper = imapper;
            _Ipessoa = ipessoa;
            _IServicePessoa = iservicePessoa;
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
        [HttpPost("/api/Pessoa/Add")]
        public async Task<IActionResult> Add(PessoaViewModel pessoa)
        {
            try
            {
                var pessoaMap = _Imapper.Map<Pessoa>(pessoa);
                await _IServicePessoa.Adicionar(pessoaMap);
                return Ok(pessoaMap);

            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPatch("/api/Pessoa/Update")]
        public async Task<IActionResult> Update(PessoaDTO pessoa)
        {
            try
            {
                var pessoaMap = _Imapper.Map<Pessoa>(pessoa);
                await _IServicePessoa.Atualizar(pessoaMap);
                return Ok(pessoaMap);

            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [Produces("application/json")]
        [HttpDelete("/api/Pessoa/Delete")]
        public async Task<IActionResult> Delete([FromQuery] PessoaIdViewModel pessoa)
        {
            try
            {
                var pessoaMap = _Imapper.Map<Pessoa>(pessoa);
                await _Ipessoa.Delete(pessoaMap);
                return Ok(pessoaMap);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Pessoa/GetEntityById")]
        public async Task<PessoaDTO> GetEntityById([FromQuery] PessoaIdViewModel pessoa)
        {
            var pessoas = await _Ipessoa.GetEntityById(pessoa.IdPessoas);
            var pessoaMap = _Imapper.Map<PessoaDTO>(pessoas);
            return pessoaMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Pessoa/List")]
        public async Task<List<PessoaDTO>> List()
        {
            var pessoa = await _Ipessoa.List();
            var pessoaMap = _Imapper.Map<List<PessoaDTO>>(pessoa);
            return pessoaMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Pessoa/ListarPessoasAtivas")]
        public async Task<List<PessoaDTO>> ListarMPessoaAtivas()
        {
            var pessoa = await _IServicePessoa.ListarPessoaAtivas();
            var pessoaMap = _Imapper.Map<List<PessoaDTO>>(pessoa);
            return pessoaMap;
        }
    }
}
