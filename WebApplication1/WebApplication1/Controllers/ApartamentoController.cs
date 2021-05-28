using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Domain.Apartamentos.Interfaces;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApartamentoController : ControllerBase
    {
        private readonly ILogger<ApartamentoController> _logger;
        private IApartamentoService _apartamentoService;

        public ApartamentoController(ILogger<ApartamentoController> logger, IApartamentoService apartamentoService)
        {
            _logger = logger;
            _apartamentoService = apartamentoService;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_apartamentoService.FindAll());
        }
        
        
    }
}