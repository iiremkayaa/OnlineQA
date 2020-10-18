using Microsoft.EntityFrameworkCore;
using Project.OnlineQA.DataAccess.Concrete.EfCore.Context;
using Project.OnlineQA.DataAccess.Interface;
using Project.OnlineQA.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.OnlineQA.DataAccess.Concrete.EfCore.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public async Task<List<User>> GetByParams(string username, string name, string lastname,string email)
        {
            var context = new OnlineQADbContext();
            List<User> users = new List<User>();
            if(username==null && name==null && lastname==null && email == null)
            {
                users = await context.Users.ToListAsync();
            }
            if (username != null)
            {
                users = await context.Users.Where(I => I.UserName == username).ToListAsync();
            }
            if (name != null)
            {
                users = await context.Users.Where(I => I.Name == name).ToListAsync();
            }
            if (lastname != null)
            {
                users = await context.Users.Where(I => I.LastName == lastname).ToListAsync();
            }
            if (email != null)
            {
                users = await context.Users.Where(I => I.Email == email).ToListAsync();
            }
            return users;
        }

        public async Task<User> GetByUserName(string userName)
        {
            using var context = new OnlineQADbContext();
            return await  context.Users.Where(I => I.UserName == userName).FirstOrDefaultAsync();
        }
    }
}
