using Project.OnlineQA.Business.Interface;
using Project.OnlineQA.DataAccess.Interface;
using Project.OnlineQA.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.OnlineQA.Business.Concrete
{
    public class UserSelectionService :GenericService<UserSelection> ,IUserSelectionService
    {
        private readonly IUserSelectionRepository _userSelectionRepository;
        public UserSelectionService(IGenericRepository<UserSelection> genericRepository,IUserSelectionRepository userSelectionRepository):base(genericRepository)
        {
            _userSelectionRepository = userSelectionRepository;
        }
    }
}
