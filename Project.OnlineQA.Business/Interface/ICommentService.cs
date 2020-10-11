using Project.OnlineQA.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.OnlineQA.Business.Interface
{
    public interface ICommentService:IGenericService<Comment>
    {
        Task<List<Comment>> GetByParams(int? questionId, int? userId);
    }
}
