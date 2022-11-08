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
    }
}
