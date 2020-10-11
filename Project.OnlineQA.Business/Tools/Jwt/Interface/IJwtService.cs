using Project.OnlineQA.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.OnlineQA.Business.Tools.Jwt.Interface
{
    public interface IJwtService
    {
        User Authenticate(string username, string password);
    }
}
