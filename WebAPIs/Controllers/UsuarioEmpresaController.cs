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
    }
}
