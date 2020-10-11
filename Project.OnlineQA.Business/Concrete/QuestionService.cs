using Project.OnlineQA.Business.Interface;
using Project.OnlineQA.DataAccess.Interface;
using Project.OnlineQA.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.OnlineQA.Business.Concrete
{
    public class QuestionService :GenericService<Question>,IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        public QuestionService(IGenericRepository<Question> genericRepository, IQuestionRepository questionRepository) :base(genericRepository)
        {
            _questionRepository = questionRepository;

        }

        public async Task<List<Question>> GetByParams(int? userId)
        {
            return await _questionRepository.GetByParams(userId);
        }
    }
}
