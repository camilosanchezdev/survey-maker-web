using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace SurveyMakerApi.Core.Domain.Repositories
{
    public interface IRepository<TEntity>
    {
        DbContext GetContext();
        Type GetEntityType();
        IDbContextTransaction BeginTransaction();
        Task<IQueryable<TEntity>> All(bool allAll = false);
        Task<IQueryable<TEntity>> Get(int id);
        Task<TEntity> Insert(TEntity model);
        Task<TEntity> Update(TEntity model);
        Task SaveChanges();
    }
}
