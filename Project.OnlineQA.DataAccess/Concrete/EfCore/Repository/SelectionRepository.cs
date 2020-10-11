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
    public class SelectionRepository : GenericRepository<Selection>, ISelectionRepository
    {
        public async Task<List<Selection>> GetByParams(int? questionId)
        {
            using var context = new OnlineQADbContext();
            List<Selection> selections = new List<Selection>();
            if (questionId == null)
            {
                selections = await context.Selections.ToListAsync();
            }
            else
            {
                selections = await context.Selections.Where(I => I.QuestionId == questionId).ToListAsync();
            }

            return selections;
        }
    }
}
