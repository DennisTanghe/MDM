using DT.MDM.Models;
using DT.MDM.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DT.MDM.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResourcesController : ControllerBase
    {
        private readonly ILogger<ResourcesController> _logger;
        private readonly ResourceService _resourceService;

        public ResourcesController(ILogger<ResourcesController> logger, ResourceService resourceService)
        {
            _logger = logger;
            _resourceService = resourceService;
        }

        /// <summary>
        /// GET: api/resources
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IQueryable<Resource> GetAll()
        {
            return _resourceService.GetAll();
        }

        /// <summary>
        /// GET: api/resources/1
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            Resource resource = await _resourceService.GetByIdAsync(id);
            
            if (resource == null)
            {
                return NotFound();
            }

            return Ok(resource);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(Resource resource)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation($"Resources POST: Invalid model state.");

                return BadRequest(ModelState);
            }

            Resource newResource = await _resourceService.AddAsync(resource, "Todo");

            return CreatedAtAction(nameof(GetByIdAsync), new { id = newResource.Id }, newResource);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Resource resource)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation($"Resources PUT: Invalid model state.");

                return BadRequest(ModelState);
            }

            Resource updResource = await _resourceService.UpdateAsync(resource, "Todo");

            return AcceptedAtAction(nameof(GetByIdAsync), new { id = updResource.Id }, updResource);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Resource resource)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation($"Resources POST: Invalid model state.");

                return BadRequest(ModelState);
            }

            Resource delResource = await _resourceService.DeleteAsync(resource);

            return Ok(delResource);
        }
    }
}
