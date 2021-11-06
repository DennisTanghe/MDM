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
    public class FieldsController : ControllerBase
    {
        private readonly ILogger<FieldsController> _logger;
        private readonly FieldService _fieldService;

        public FieldsController(ILogger<FieldsController> logger, FieldService fieldService)
        {
            _logger = logger;
            _fieldService = fieldService;
        }

        /// <summary>
        /// GET: api/fields
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IQueryable<Field> GetAll()
        {
            return _fieldService.GetAll();
        }

        /// <summary>
        /// GET: api/fields/1
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            Field field = await _fieldService.GetByIdAsync(id);
            
            if (field == null)
            {
                return NotFound();
            }

            return Ok(field);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(Field field)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation($"Fields POST: Invalid model state.");

                return BadRequest(ModelState);
            }

            Field newField = await _fieldService.AddAsync(field, "Todo");

            return CreatedAtAction(nameof(GetByIdAsync), new { id = newField.Id }, newField);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Field field)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation($"Fields PUT: Invalid model state.");

                return BadRequest(ModelState);
            }

            Field updField = await _fieldService.UpdateAsync(field, "Todo");

            return AcceptedAtAction(nameof(GetByIdAsync), new { id = updField.Id }, updField);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Field field)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation($"Fields POST: Invalid model state.");

                return BadRequest(ModelState);
            }

            Field delField = await _fieldService.DeleteAsync(field);

            return Ok(delField);
        }
    }
}
