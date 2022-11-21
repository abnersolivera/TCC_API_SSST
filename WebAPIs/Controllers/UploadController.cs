using Entities.Entities.Pessoas;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;
using Domain.Services;
using Domain.Interfaces;
using Azure;

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
        public async Task<string> Add(UploadViewModel image)
        {
            try
            {
                return await _IUpload.UploadBase64(image.Image, "user");

            }
            catch(RequestFailedException e)
            {
                Response.StatusCode = 400;
                return BadRequest(e.ErrorCode).ToString()!;
            }


        }
    }
}
