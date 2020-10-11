using Project.OnlineQA.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.OnlineQA.DataAccess.Interface
{
    public interface IUserRepository :IGenericRepository<User>
    {
        Task<User> GetByUserName(string userName);
        Task<List<User>> GetByParams(string username, string name, string lastname,string email);
    }
}
