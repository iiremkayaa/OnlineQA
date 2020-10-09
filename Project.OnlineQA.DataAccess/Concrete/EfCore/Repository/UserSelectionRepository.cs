using Project.OnlineQA.DataAccess.Interface;
using Project.OnlineQA.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.OnlineQA.DataAccess.Concrete.EfCore.Repository
{
    public class UserSelectionRepository : GenericRepository<UserSelection> ,IUserSelectionRepository
    {
       
    }
}
