using Project.OnlineQA.Business.Interface;
using Project.OnlineQA.DataAccess.Interface;
using Project.OnlineQA.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.OnlineQA.Business.Concrete
{
    public class UserService :GenericService<User>,IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository,IGenericRepository<User> genericRepository):base(genericRepository)
        {
            _userRepository = userRepository;
        }

        public Task<List<User>> GetByParams(string username,string name,string lastname,string email)
        {
            return _userRepository.GetByParams(username,name,lastname,email);
        }

        public Task<User> GetByUserName(string userName)
        {
            return _userRepository.GetByUserName(userName);
        }
    }
}
