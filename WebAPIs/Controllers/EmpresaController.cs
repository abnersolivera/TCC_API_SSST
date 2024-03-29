﻿using AutoMapper;
using Domain.Interfaces.InterfaceServices;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using WebAPIs.Models;
using Entities.Entities.Empresas;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IMapper _Imapper;

        private readonly IEmpresa _IEmpresa;
        private readonly IServiceEmpresa _IServiceEmpresa;

        public EmpresaController(IMapper imapper, IEmpresa iEmpresa, IServiceEmpresa iServiceEmpresa)
        {
            _Imapper = imapper;
            _IEmpresa = iEmpresa;
            _IServiceEmpresa = iServiceEmpresa;
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
        [HttpPost("/api/Empresa/Add")]
        public async Task<Notifies2<Empresa>> Add(EmpresaViewModel empresa)
        {            
            var empresaMap = _Imapper.Map<Empresa>(empresa);
            var result = await _IServiceEmpresa.Adicionar(empresaMap);
            return result;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPatch("/api/Empresa/Update")]
        public async Task<Notifies2<Empresa>> Update(EmpresaViewModel empresa)
        {
            var empresaMap = _Imapper.Map<Empresa>(empresa);
            var result = await _IServiceEmpresa.Atualizar(empresaMap);
            return result;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpDelete("/api/Empresa/Delete")]
        public async Task<Empresa> Delete([FromQuery] EmpresaIdViewModel empresa)
        {
            var empresaMap = _Imapper.Map<Empresa>(empresa);
            await _IEmpresa.Delete(empresaMap);
            return empresaMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Empresa/GetEntityById")]
        public async Task<EmpresaDTO> GetEntityById([FromQuery] EmpresaIdViewModel empresa)
        {
            var empresas = await _IEmpresa.GetEntityById(empresa.IdEmpresa);
            var empresaMap = _Imapper.Map<EmpresaDTO>(empresas);
            return empresaMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Empresa/List")]
        public async Task<List<EmpresaDTO>> List()
        {
            var empresa = await _IEmpresa.List();
            var empresaMap = _Imapper.Map<List<EmpresaDTO>>(empresa);
            return empresaMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Empresa/ListarEmpresaAtivas")]
        public async Task<List<EmpresaDTO>> ListarEmpresaAtivas()
        {
            var empresa = await _IServiceEmpresa.ListarEmpresaAtivas();
            var empresaMap = _Imapper.Map<List<EmpresaDTO>>(empresa);
            return empresaMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Empresa/ListarNomeEmpresa")]
        public async Task<List<EmpresaDTO>> ListarNomeEmpresa(string? nome, int? id, string? cnpj, string? cpf)
        {
            var empresa = await _IServiceEmpresa.ListarNomeEmpresaId(nome, id, cnpj, cpf);
            var empresaMap = _Imapper.Map<List<EmpresaDTO>>(empresa);
            return empresaMap;
        }
    }
}
