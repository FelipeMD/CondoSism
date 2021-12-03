﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.ValueObjetcs;
using API.Hypermedia.Filters;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [ApiController]
    [Authorize("Bearer")]
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
        
        [HttpGet("{sortDirection}/{pageSize}/{page}")]
        [ProducesResponseType((200), Type = typeof(List<MoradorVo>))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult FindByPaginado([FromQuery] string name, 
            string sortDirection, 
            int pageSize, 
            int page)
        {
            return Ok(_moradorService.FindWithPagedSearch(name, sortDirection, pageSize, page));
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
        
        [HttpGet("findMoradorByName")]
        [ProducesResponseType((200), Type = typeof(MoradorVo))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult FindMoradorByName([FromQuery] string firstName, [FromQuery] string lastName)
        {
            var morador = _moradorService.FindByName(firstName, lastName);
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
        
        [HttpPatch("{id}")]
        [ProducesResponseType((200), Type = typeof(MoradorVo))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Disable(long id)
        {
            var morador = _moradorService.Disable(id);
            return Ok(morador);
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
