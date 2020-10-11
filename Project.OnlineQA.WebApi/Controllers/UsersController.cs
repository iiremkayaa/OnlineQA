﻿using System;
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
using Project.OnlineQA.WebApi.QueryParameters;

namespace Project.OnlineQA.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UsersController(IUserService userService,IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;

        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<UserListModel>(await _userService.FindByIdAsync(id)));
        }
        
        [HttpGet]
        public async Task<IActionResult> GetByParams(string username,string name, string lastname,string email)
        {
            
            return Ok(_mapper.Map<List<UserListModel>>(await _userService.GetByParams(username,name,lastname,email)));
            
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserAddDto userAddDto)
        {
            await  _userService.AddAsync(_mapper.Map<User>(userAddDto));
            return Created("", userAddDto);
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
