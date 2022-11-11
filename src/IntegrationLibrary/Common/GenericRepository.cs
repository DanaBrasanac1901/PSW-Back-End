using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IntegrationLibrary.Common
{
    public class GenericRepository<T>: IGenericRepository<T> where T : class{
        protected readonly DbSet<T> DbSet;
     /*   protected GenericRepository(IntegrationDbContext dbContext){
            DbSet= dbContext.Set<T>();
        }*/

        public async Task<T> GetByIdAsync(Guid id){
            return await DbSet.FindAsync(id);
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        

        public async Task<T> CreateAsync(T entity){
            await DbSet.AddAsync(entity);
            return entity;
        }
        public Task DeleteAsync(T entity){
             DbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task DeleteByIdAsync(Guid guid){

            var entity = await GetByIdAsync(guid);
            if( entity == null){
                return;
            }
            DbSet.Remove(entity);
        }

        public Task UpdateAsync(T entity){
            var entityUpdate = DbSet.Update(entity);
            return Task.FromResult(entityUpdate);
        }


    }
}