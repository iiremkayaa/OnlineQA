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
    [Route("api/comments")]
    [ApiController]
    public class CommentsController : BaseController
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        public CommentsController(ICommentService commentService,IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]  int id)
        {
            return Ok(_mapper.Map<CommentListModel>(await _commentService.FindByIdAsync(id)));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment([FromRoute] int id,[FromQuery] CommentUpdateDto commentUpdateDto)
        {
            if (id != commentUpdateDto.Id)
            {
                return BadRequest();
            }
            await _commentService.UpdateAsync(_mapper.Map<Comment>(commentUpdateDto));
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment([FromRoute] int id)
        {
            await _commentService.RemoveAsync(id);
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> CreateComment([FromQuery] CommentAddDto commentAddDto)
        {
            commentAddDto.CommentDate = DateTime.Now;
            await _commentService.AddAsync(_mapper.Map<Comment>(commentAddDto));
            return Created("", commentAddDto);
        }
        [HttpGet]
        public async Task<IActionResult> GetByParams([FromQuery] int? questionId, [FromQuery] int? userId)
        {
            return Ok(_mapper.Map<List<CommentListModel>>(await _commentService.GetByParams(questionId,userId)));

        }
    }
}
