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
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;
        public QuestionsController(IQuestionService questionService,IMapper mapper)
        {
            _questionService = questionService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {   
           return Ok(_mapper.Map<List<QuestionListModel>>(await _questionService.GetAllAsync()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<QuestionListModel>(await _questionService.FindByIdAsync(id)));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(int id, Question question)
        {
            if (id != question.Id)
            {
                return BadRequest();
            }
            await _questionService.UpdateAsync(question);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            await _questionService.RemoveAsync(id);
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> CreateQuestion(QuestionAddDto questionAddDto)
        {
            questionAddDto.PostedTime = DateTime.Now;
            await _questionService.AddAsync(_mapper.Map<Question>(questionAddDto));
            return Created("", questionAddDto);
        }
    }
}
