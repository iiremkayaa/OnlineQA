using Project.OnlineQA.Business.Interface;
using Project.OnlineQA.DataAccess.Interface;
using Project.OnlineQA.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.OnlineQA.Business.Concrete
{
    public class CommentService :GenericService<Comment>,ICommentService
    {
        private ICommentRepository _commentRepository;
        public CommentService(IGenericRepository<Comment> genericRepository, ICommentRepository commentRepository) :base(genericRepository)
        {
            _commentRepository = commentRepository;
        }
        public Task<List<Comment>> GetByParams(int? questionId, int? userId)
        {
           
            return _commentRepository.GetByParams(questionId,  userId);
        }
    }
}
