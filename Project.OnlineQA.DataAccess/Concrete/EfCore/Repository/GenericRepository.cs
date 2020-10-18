using Project.OnlineQA.DataAccess.Interface;
using Project.OnlineQA.Entities.Interface;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using Project.OnlineQA.DataAccess.Concrete.EfCore.Context;
using Microsoft.EntityFrameworkCore;

namespace Project.OnlineQA.DataAccess.Concrete.EfCore.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T:class,ITable,new()
    {
        public async Task AddAsync(T entity)
        {
            using var context= new OnlineQADbContext();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            using var context = new OnlineQADbContext();
            var entity = await context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                entity = await context.Set<T>().FindAsync(id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
            }
           
        }

        public async Task<List<T>> GetAllAsync()
        {
            using var context = new OnlineQADbContext();
            return await context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            using var context = new OnlineQADbContext();
            return await context.Set<T>().FindAsync(id);
        }

        public async  Task UpdateAsync(T entity)
        {
            using var context = new OnlineQADbContext();
            context.Update(entity);
            await context.SaveChangesAsync();

        }
    }
}
