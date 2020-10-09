using Project.OnlineQA.DataAccess.Interface;
using Project.OnlineQA.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.OnlineQA.DataAccess.Concrete.EfCore.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T:class,ITable,new()
    {
        public Task AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
