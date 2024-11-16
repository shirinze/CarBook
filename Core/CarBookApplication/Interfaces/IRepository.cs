using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Interfaces
{
    public interface IRepository<T> where T:class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIDAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
    }
}
