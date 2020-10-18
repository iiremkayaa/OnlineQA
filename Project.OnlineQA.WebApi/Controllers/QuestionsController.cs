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
    [Route("api/questions")]
    [ApiController]
    public class QuestionsController : BaseController
    {
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;
        public QuestionsController(IQuestionService questionService,IMapper mapper)
        {
            _questionService = questionService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetByParams([FromQuery] int? userId = null)
        {
            return Ok(_mapper.Map<List<QuestionListModel>>(await _questionService.GetByParams( userId)));

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            return Ok(_mapper.Map<QuestionListModel>(await _questionService.FindByIdAsync(id)));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion([FromRoute] int id, [FromQuery] QuestionUpdateDto questionUpdateDto)
        {
            if (id != questionUpdateDto.Id)
            {
                return BadRequest();
            }
            await _questionService.UpdateAsync(_mapper.Map<Question>(questionUpdateDto));
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion([FromRoute] int id)
        {
            await _questionService.RemoveAsync(id);
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> CreateQuestion([FromQuery] QuestionAddDto questionAddDto)
        {
            questionAddDto.PostedTime = DateTime.Now;
            await _questionService.AddAsync(_mapper.Map<Question>(questionAddDto));
            return Created("", questionAddDto);
        }
    }
}
