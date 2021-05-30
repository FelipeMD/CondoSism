using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Data.ValueObjetcs;
using WebApplication1.Domain.Apartamentos;
using WebApplication1.Domain.Apartamentos.Interfaces;
using WebApplication1.Hypermedia.Filters;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Authorize("Bearer")]
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
        [ProducesResponseType((200), Type = typeof(List<ApartamentoVo>))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_apartamentoService.FindAll());
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(ApartamentoVo))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult FindById(long id)
        {
            var apartamento = _apartamentoService.FindById(id);
            if (apartamento == null) return NotFound();
            return Ok(apartamento);
        }
        
        [HttpPost]
        [ProducesResponseType((200), Type = typeof(ApartamentoVo))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Create([FromBody] ApartamentoVo apartamento)
        {
            if (apartamento == null) return NotFound();
            return Ok(_apartamentoService.Create(apartamento));
        }
        
        [HttpPut]
        [ProducesResponseType((200), Type = typeof(ApartamentoVo))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Update([FromBody] ApartamentoVo apartamento)
        {
            if (apartamento == null) return NotFound();
            return Ok(_apartamentoService.Update(apartamento));
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(long id)
        {
            _apartamentoService.Delete(id);
            return NoContent();
        }
    }
}