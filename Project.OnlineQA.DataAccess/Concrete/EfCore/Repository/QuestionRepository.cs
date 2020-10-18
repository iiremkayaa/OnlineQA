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
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        

        public async Task<List<Question>> GetByParams(int? userId)
        {
            using var context = new OnlineQADbContext();
            List<Question> questions = new List<Question>();
            if ( userId == null)
            {
                questions = await context.Questions.Include(a => a.User).AsNoTracking().ToListAsync();
            }
           else
            {
                questions = await context.Questions.Include(a => a.User).AsNoTracking().Where(I => I.UserId == userId).ToListAsync();
            }
            

            return questions;
        }
    }
}
