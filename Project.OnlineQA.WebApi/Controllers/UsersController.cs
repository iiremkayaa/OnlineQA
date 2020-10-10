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
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _userService.FindByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            await _userService.AddAsync(user);
            return Created("", user);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id,User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            await _userService.UpdateAsync(user);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.RemoveAsync(id);
            return NoContent();
        }
    }
}
