using Entities.Entities.Pessoas;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;
using Domain.Services;
using Domain.Interfaces;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IUpload _IUpload;

        public UploadController(IUpload iUpload)
        {
            _IUpload = iUpload;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/Upload/Add")]
        public Task<string> Add(UploadViewModel image)
        {    
            return _IUpload.UploadBase64(image.Image,"user");
        }
    }
}
