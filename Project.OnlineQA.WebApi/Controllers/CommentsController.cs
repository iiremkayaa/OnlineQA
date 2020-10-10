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
    [Route("api/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _commentService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _commentService.FindByIdAsync(id));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(int id, Comment comment)
        {
            if (id != comment.Id)
            {
                return BadRequest();
            }
            await _commentService.UpdateAsync(comment);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            await _commentService.RemoveAsync(id);
            return NoContent();
        }
    }
}
