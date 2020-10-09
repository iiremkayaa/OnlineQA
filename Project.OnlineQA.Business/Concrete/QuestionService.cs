using Project.OnlineQA.Business.Interface;
using Project.OnlineQA.DataAccess.Interface;
using Project.OnlineQA.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.OnlineQA.Business.Concrete
{
    public class QuestionService :GenericService<Question>,IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        public QuestionService(IGenericRepository<Question> genericRepository, IQuestionRepository questionRepository) :base(genericRepository)
        {
            _questionRepository = questionRepository;

        }
    }
}
