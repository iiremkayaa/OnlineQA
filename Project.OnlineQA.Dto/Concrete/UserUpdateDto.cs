﻿using Project.OnlineQA.Dto.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.OnlineQA.Dto.Concrete
{
    public class UserUpdateDto :IDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
