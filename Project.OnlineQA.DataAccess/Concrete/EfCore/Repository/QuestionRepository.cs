using Project.OnlineQA.DataAccess.Interface;
using Project.OnlineQA.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.OnlineQA.DataAccess.Concrete.EfCore.Repository
{
    public class QuestionRepository: GenericRepository<Question>,IQuestionRepository 
    {
    }
}
