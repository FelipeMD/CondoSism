using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.ValueObjetcs;
using WebApplication1.Domain.Files.Interfaces;

namespace WebApplication1.Controllers
{
    
    [ApiController]
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("uploadFile")]
        [ProducesResponseType((200), Type = typeof(FileDetailVo))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Produces("application/json")]
        public async Task<IActionResult> UploadOneFile([FromForm] IFormFile file)
        {
            FileDetailVo detail = await _fileService.SaveFileToDisk(file);
            return new OkObjectResult(detail);
        }
    }
}