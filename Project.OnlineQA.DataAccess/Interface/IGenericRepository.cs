using Project.OnlineQA.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Project.OnlineQA.DataAccess.Interface
{
    public interface IGenericRepository<T> where T: class, ITable, new()
    {
        Task<List<T>> GetAllAsync();

        Task<T> GetAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
