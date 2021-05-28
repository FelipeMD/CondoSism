using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Domain.Apartamentos;
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
        
        [HttpGet("{id}")]
        public IActionResult FindById(long id)
        {
            var apartamento = _apartamentoService.FindById(id);
            if (apartamento == null) return NotFound();
            return Ok(apartamento);
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] Apartamento apartamento)
        {
            if (apartamento == null) return NotFound();
            return Ok(_apartamentoService.Create(apartamento));
        }
        
        [HttpPut]
        public IActionResult Update([FromBody] Apartamento apartamento)
        {
            if (apartamento == null) return NotFound();
            return Ok(_apartamentoService.Update(apartamento));
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _apartamentoService.Delete(id);
            return NoContent();
        }
    }
}