using Entities.Entities.Pessoas;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;
using Domain.Services;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {


        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/Upload/Add")]
        public async Task<string> Add(UploadViewModel image)
        {
            var uploadService = new RepositoryUpload();
            return uploadService.UploadBase64(image.Image,"user");
        }
    }
}
