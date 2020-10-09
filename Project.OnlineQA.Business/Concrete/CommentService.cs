using Project.OnlineQA.Business.Interface;
using Project.OnlineQA.DataAccess.Interface;
using Project.OnlineQA.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.OnlineQA.Business.Concrete
{
    public class CommentService :GenericService<Comment>,ICommentService
    {
        private ICommentRepository _commentRepository;
        public CommentService(IGenericRepository<Comment> genericRepository, ICommentRepository commentRepository) :base(genericRepository)
        {
            _commentRepository = commentRepository;
        }
    }
}
