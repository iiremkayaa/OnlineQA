﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.OnlineQA.Business.Interface;
using Project.OnlineQA.Dto.Concrete;
using Project.OnlineQA.Entities.Concrete;
using Project.OnlineQA.WebApi.Models;

namespace Project.OnlineQA.WebApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UsersController(IUserService userService,IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            return Ok(_mapper.Map<UserListModel>(await _userService.FindByIdAsync(id)));
        }
        
       
        [HttpGet]
        public async Task<IActionResult> GetByParams([FromQuery] string username , [FromQuery]  string name, [FromQuery]  string lastname, [FromQuery]  string email)
        {
            return Ok(_mapper.Map<List<UserListModel>>(await _userService.GetByParams(username,name,lastname,email)));
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromQuery] UserAddDto userAddDto)
        {
            userAddDto.Password = ComputeSha256Hash(userAddDto.Password);
            var isExist = await _userService.GetByUserName(userAddDto.UserName);
            if (isExist == null)
            {
                await _userService.AddAsync(_mapper.Map<User>(userAddDto));
                return Created("", userAddDto);
            }
            else
            {
                return BadRequest("Username was already taken!");
            }
            
            
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute]int id,[FromQuery] UserUpdateDto userUpdateDto)
        {
            
            if (id != userUpdateDto.Id)
            {
                return BadRequest(); 
            }
            await _userService.UpdateAsync(_mapper.Map<User>(userUpdateDto));
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            await _userService.RemoveAsync(id);
            return NoContent();
        }
    }
}
