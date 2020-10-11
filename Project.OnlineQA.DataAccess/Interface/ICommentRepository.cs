using Project.OnlineQA.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.OnlineQA.DataAccess.Interface
{
    public interface ICommentRepository :IGenericRepository<Comment>
    {
        Task<List<Comment>> GetByParams(int? questionId, int? userId);
    }
}
