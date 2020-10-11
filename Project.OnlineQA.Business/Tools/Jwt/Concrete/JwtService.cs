using Project.OnlineQA.Business.Tools.Jwt.Interface;
using Project.OnlineQA.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.OnlineQA.Business.Tools.Jwt.Concrete
{
    public class JwtService : IJwtService
    {
        public User Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
