using Project.OnlineQA.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.OnlineQA.Business.Interface
{
    public interface ISelectionService :IGenericService<Selection>
    {
        Task<List<Selection>> GetByParams(int? questionId);
    }
}
