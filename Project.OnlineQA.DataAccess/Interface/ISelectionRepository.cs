using Project.OnlineQA.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.OnlineQA.DataAccess.Interface
{
    public interface ISelectionRepository :IGenericRepository<Selection>
    {
        Task<List<Selection>> GetByParams(int? questionId);
    }
}
