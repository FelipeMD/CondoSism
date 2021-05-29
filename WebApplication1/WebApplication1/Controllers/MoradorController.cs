using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.ValueObjetcs;
using WebApplication1.Domain.Moradores;
using WebApplication1.Domain.Moradores.Interfaces;
using WebApplication1.Hypermedia.Filters;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoradorController : ControllerBase
    {
        private readonly ILogger<MoradorController> _logger;
        private IMoradorService _moradorService;

        public MoradorController(ILogger<MoradorController> logger, IMoradorService moradorService)
        {
            _logger = logger;
            _moradorService = moradorService;
        }
        
        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<MoradorVo>))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_moradorService.FindAll());
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(MoradorVo))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult FindById(long id)
        {
            var morador = _moradorService.FindById(id);
            if (morador == null) return NotFound();
            return Ok(morador);
        }
        
        [HttpPost]
        [ProducesResponseType((200), Type = typeof(MoradorVo))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Create([FromBody] MoradorVo morador)
        {
            if (morador == null) return NotFound();
            return Ok(_moradorService.Create(morador));
        }
        
        [HttpPut]
        [ProducesResponseType((200), Type = typeof(MoradorVo))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Update([FromBody] MoradorVo morador)
        {
            if (morador == null) return NotFound();
            return Ok(_moradorService.Update(morador));
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(long id)
        {
            _moradorService.Delete(id);
            return NoContent();
        }
    }
}
