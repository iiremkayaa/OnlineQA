using Project.OnlineQA.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.OnlineQA.Business.Interface
{
    public interface IQuestionService:IGenericService<Question>
    {
        Task<List<Question>> GetByParams(int? userId);
    }
}
