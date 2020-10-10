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
    [Route("api/[controller]")]
    [ApiController]
    public class SelectionsController : ControllerBase
    {
        private readonly ISelectionService _selectionService;
        private readonly IMapper _mapper;
        public SelectionsController(ISelectionService selectionService, IMapper mapper)
        {
            _selectionService = selectionService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<SelectionListModel>>(await _selectionService.GetAllAsync()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<SelectionListModel>(await _selectionService.FindByIdAsync(id)));
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
        [HttpPost]
        public async Task<IActionResult> CreateSelection(SelectionAddDto selectionAddDto)
        {
            selectionAddDto.NumberOfSelection = 0;
            await _selectionService.AddAsync(_mapper.Map<Selection>(selectionAddDto));
            return Created("", selectionAddDto);
        }
    }
}
