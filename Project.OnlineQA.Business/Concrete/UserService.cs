using Project.OnlineQA.Business.Interface;
using Project.OnlineQA.DataAccess.Interface;
using Project.OnlineQA.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.OnlineQA.Business.Concrete
{
    public class UserService :GenericService<User>,IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository,IGenericRepository<User> genericRepository):base(genericRepository)
        {
            _userRepository = userRepository;
        }
    }
}
