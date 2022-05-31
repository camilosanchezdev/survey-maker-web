using SurveyMakerApi.Core.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace SurveyMakerApi.Core.Domain.Services
{
    public class Service<TModelEntity> : IService<TModelEntity>
        where TModelEntity : class, new()
    {
        protected IRepository<TModelEntity> _repository;
        protected readonly IServiceProvider serviceProvider;
        protected readonly Lazy<IHttpContextAccessor> _httpContextAccessor;

        public Service(IRepository<TModelEntity> repository, IServiceProvider serviceProvider)
        {
            _repository = repository;
            _httpContextAccessor = new Lazy<IHttpContextAccessor>(() => serviceProvider.GetRequiredService<IHttpContextAccessor>());
        }
        public DbContext GetContext()
        {
            return _repository.GetContext();
        }
        public virtual async Task<IQueryable<TModelEntity>> All(bool includes = false, bool allAll = false)
        {
            var records = await _repository.All(allAll);

            if (includes)
            {
                records = Includes(records);
            }

            return records;
        }
        public virtual IQueryable<TModelEntity> Includes(IQueryable<TModelEntity> records)
        {
            return records;
        }
        public virtual async Task<TModelEntity> Insert(TModelEntity entity, IDbContextTransaction inheritedTransaction = null)
        {
            var transaction = inheritedTransaction ?? _repository.BeginTransaction();

            try
            {
                entity = await _repository.Insert(entity);

                if (inheritedTransaction == null)
                {
                    transaction.Commit();
                }

                return entity;
            }
            catch
            {
                if (inheritedTransaction == null)
                {
                    transaction.Rollback();
                }

                throw;
            }
        }


        public virtual async Task<TModelEntity> Update(TModelEntity entity, IDbContextTransaction inheritedTransaction = null)
        {
            var transaction = inheritedTransaction ?? _repository.BeginTransaction();

            try
            {
                entity = await _repository.Update(entity);

                if (inheritedTransaction == null)
                {
                    transaction.Commit();
                }

                return entity;
            }
            catch (Exception)
            {
                if (inheritedTransaction == null)
                {
                    transaction.Rollback();
                }

                throw;
            }
        }

        public virtual async Task<IQueryable<TModelEntity>> Get(int id)
        {
            var records = await _repository.Get(id);

            return records;
        }
    }
}
