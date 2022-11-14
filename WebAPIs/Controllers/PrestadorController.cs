﻿using AutoMapper;
using Domain.Interfaces.InterfaceServices;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.Services;
using Entities.Entities.Pessoas;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using WebAPIs.Models;
using Entities.Entities.Prestadores;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestadorController : ControllerBase
    {
        private readonly IMapper _Imapper;

        private readonly IPrestador _IPrestador;
        private readonly IServicePrestador _IServicePrestador;

        public PrestadorController(IMapper iMapper, IPrestador iPrestador, IServicePrestador iServicePrestador)
        {
            _Imapper = iMapper;
            _IPrestador = iPrestador;
            _IServicePrestador = iServicePrestador;
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
        [HttpPost("/api/Prestador/Add")]
        public async Task<List<Notifies>> Add(PrestadorViewModel prestador)
        {
            var prestadorMap = _Imapper.Map<Prestador>(prestador);
            await _IServicePrestador.Adicionar(prestadorMap);
            return prestadorMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPatch("/api/Prestador/Update")]
        public async Task<List<Notifies>> Update(PrestadorViewModel prestador)
        {
            var prestadorMap = _Imapper.Map<Prestador>(prestador);
            await _IServicePrestador.Atualizar(prestadorMap);
            return prestadorMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpDelete("/api/Prestador/Delete")]
        public async Task<List<Notifies>> Delete([FromQuery] PrestadorIdViewModel prestador)
        {
            var prestadorMap = _Imapper.Map<Prestador>(prestador);
            await _IPrestador.Delete(prestadorMap);
            return prestadorMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Prestador/GetEntityById")]
        public async Task<PrestadorDTO> GetEntityById([FromQuery] PrestadorIdViewModel prestador)
        {
            var prestadores = await _IPrestador.GetEntityById(prestador.IdPrestador);
            var pessoaMap = _Imapper.Map<PrestadorDTO>(prestador);
            return pessoaMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Prestador/List")]
        public async Task<List<PrestadorDTO>> List()
        {
            var prestador = await _IPrestador.List();
            var pessoaMap = _Imapper.Map<List<PrestadorDTO>>(prestador);
            return pessoaMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Prestador/ListarPrestadorAtivos")]
        public async Task<List<PrestadorDTO>> ListarPrestadorAtivos()
        {
            var prestador = await _IServicePrestador.ListarPrestadorAtivas();
            var prestadorMap = _Imapper.Map<List<PrestadorDTO>>(prestador);
            return prestadorMap;
        }
    }
}
