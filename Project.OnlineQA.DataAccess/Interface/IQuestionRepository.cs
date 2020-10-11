using Project.OnlineQA.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.OnlineQA.DataAccess.Interface
{
    public interface IQuestionRepository :IGenericRepository<Question>
    {
        Task<List<Question>> GetByParams(int? userId);
    }
}
