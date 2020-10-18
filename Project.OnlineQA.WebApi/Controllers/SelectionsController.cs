using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.OnlineQA.Business.Interface;
using Project.OnlineQA.Dto.Concrete;
using Project.OnlineQA.Entities.Concrete;
using Project.OnlineQA.WebApi.Models;

namespace Project.OnlineQA.WebApi.Controllers
{
    [Route("api/selections")]
    [ApiController]
    public class SelectionsController : BaseController
    {
        private readonly ISelectionService _selectionService;
        private readonly IMapper _mapper;
        public SelectionsController(ISelectionService selectionService, IMapper mapper)
        {
            _selectionService = selectionService;
            _mapper = mapper;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            return Ok(_mapper.Map<SelectionListModel>(await _selectionService.FindByIdAsync(id)));
        }
        [HttpGet]
        public async Task<IActionResult> GetByParams([FromQuery] int? questionId)
        {

            return Ok(_mapper.Map<List<SelectionListModel>>(await _selectionService.GetByParams(questionId)));

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSelection([FromRoute]int id, [FromQuery] Selection selection)
        {
            if (id != selection.Id)
            {
                return BadRequest();
            }
            await _selectionService.UpdateAsync(selection);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSelection([FromRoute]int id)
        {
            await _selectionService.RemoveAsync(id);
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSelection([FromQuery] SelectionAddDto selectionAddDto)
        {
            selectionAddDto.NumberOfSelection = 0;
            await _selectionService.AddAsync(_mapper.Map<Selection>(selectionAddDto));
            return Created("", selectionAddDto);
        }
    }
}
