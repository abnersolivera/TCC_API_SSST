using Entities.Entities.Pessoas;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;
using Domain.Services;
using Domain.Interfaces;
using Azure;
using Microsoft.AspNetCore.Http.Extensions;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController(IUpload iUpload) : ControllerBase
    {
        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/Upload/Add")]
        public async Task<IActionResult> Add(UploadViewModel image)
        {
            try
            {
                return Created(HttpContext.Request.GetDisplayUrl(),await iUpload.UploadBase64(image.Image));

            }
            catch(RequestFailedException e)
            {
                Response.StatusCode = 400;
                return BadRequest(e.ErrorCode);
            }


        }
    }
}
