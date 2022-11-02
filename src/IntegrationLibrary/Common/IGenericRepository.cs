using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntegrationLibrary.Common
{
    public interface IGenericRepository<T> where T:class{
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> CreateAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
    }
}