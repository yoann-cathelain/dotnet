using Microsoft.AspNetCore.Mvc;
using WebAPI_TP3.Models.EntityFramework;

namespace WebAPI_TP3.Models.Repository
{
    public interface IDataRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetByStringAsync(string str);
        Task Add(TEntity entity);
        Task Update(TEntity entityToUpdate, TEntity entity);
        Task Delete(TEntity entity);
    }
}
