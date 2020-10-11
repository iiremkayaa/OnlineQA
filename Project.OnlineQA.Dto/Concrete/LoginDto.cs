using Project.OnlineQA.Dto.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.OnlineQA.Dto.Concrete
{
    public class LoginDto :IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
