using Microsoft.EntityFrameworkCore;
using Project.OnlineQA.DataAccess.Concrete.EfCore.Context;
using Project.OnlineQA.DataAccess.Interface;
using Project.OnlineQA.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.OnlineQA.DataAccess.Concrete.EfCore.Repository
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public async Task<List<Comment>> GetByParams(int? questionId, int? userId)
        {
            using var context = new OnlineQADbContext();
            IQueryable<Comment> comments =context.Comments;

            if (questionId ==null && userId ==null )
            {
                comments = comments.Include(a => a.Question).Include(a => a.User).AsNoTracking();
            }
            if (questionId != null)
            {
                comments = comments.Include(a => a.Question).Include(a => a.User).AsNoTracking().Where(I => I.QuestionId == questionId);
            }
            if (userId != null)
            {
                comments = comments.Include(a => a.Question).Include(a => a.User).AsNoTracking().Where(I => I.UserId == userId);
            }
            



            return await comments.ToListAsync();
        }
    }
}
