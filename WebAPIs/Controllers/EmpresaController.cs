using AutoMapper;
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
        public async Task<List<Notifies>> Add(EmpresaViewModel empresa)
        {
            var empresaMap = _Imapper.Map<Empresa>(empresa);
            await _IServiceEmpresa.Adicionar(empresaMap);
            return empresaMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPatch("/api/Empresa/Update")]
        public async Task<List<Notifies>> Update(EmpresaViewModel empresa)
        {
            var empresaMap = _Imapper.Map<Empresa>(empresa);
            await _IServiceEmpresa.Atualizar(empresaMap);
            return empresaMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpDelete("/api/Empresa/Delete")]
        public async Task<List<Notifies>> Delete(EmpresaViewModel empresa)
        {
            var empresaMap = _Imapper.Map<Empresa>(empresa);
            await _IEmpresa.Delete(empresaMap);
            return empresaMap.Notitycoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/Empresa/GetEntityById")]
        public async Task<EmpresaViewModel> GetEntityById(EmpresaViewModel empresa)
        {
            var empresas = await _IEmpresa.GetEntityById(empresa.IdEmpresa);
            var empresaMap = _Imapper.Map<EmpresaViewModel>(empresas);
            return empresaMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Empresa/List")]
        public async Task<List<EmpresaViewModel>> List()
        {
            var empresa = await _IEmpresa.List();
            var empresaMap = _Imapper.Map<List<EmpresaViewModel>>(empresa);
            return empresaMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/Empresa/ListarEmpresaAtivas")]
        public async Task<List<EmpresaViewModel>> ListarMPessoaAtivas()
        {
            var empresa = await _IServiceEmpresa.ListarEmpresaAtivas();
            var empresaMap = _Imapper.Map<List<EmpresaViewModel>>(empresa);
            return empresaMap;
        }
    }
}
