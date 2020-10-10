using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.OnlineQA.Business.Interface;
using Project.OnlineQA.Entities.Concrete;

namespace Project.OnlineQA.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelectionsController : ControllerBase
    {
        private readonly ISelectionService _selectionService;
        public SelectionsController(ISelectionService selectionService)
        {
            _selectionService = selectionService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _selectionService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _selectionService.FindByIdAsync(id));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSelection(int id, Selection selection)
        {
            if (id != selection.Id)
            {
                return BadRequest();
            }
            await _selectionService.UpdateAsync(selection);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSelection(int id)
        {
            await _selectionService.RemoveAsync(id);
            return NoContent();
        }
    }
}
