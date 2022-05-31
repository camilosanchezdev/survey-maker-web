using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace SurveyMakerApi.Core.Domain.Services
{
    public interface IService<TModelEntity>
    {
        DbContext GetContext();
        Task<TModelEntity> Insert(TModelEntity model, IDbContextTransaction inheritedTransaction = null);
        Task<TModelEntity> Update(TModelEntity model, IDbContextTransaction inheritedTransaction = null);
        Task<IQueryable<TModelEntity>> Get(int id);
    }
}
