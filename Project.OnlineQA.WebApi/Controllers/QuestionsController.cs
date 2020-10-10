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
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           return Ok(await _questionService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _questionService.FindByIdAsync(id));
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
    }
}
