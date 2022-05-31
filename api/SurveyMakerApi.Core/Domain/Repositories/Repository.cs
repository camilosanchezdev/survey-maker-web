using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SurveyMakerApi.Persistence.Models;

namespace SurveyMakerApi.Core.Domain.Repositories
{
    public abstract class Repository<TContext, TEntity> : IRepository<TEntity>  
        where TEntity : BaseModel
        where TContext : DbContext 
    {
        public TContext Context { get; set; }
        public DbSet<TEntity> DataSet { get; set; }
        public Repository(TContext context)
        {
            Context = context;
        }
        public virtual async Task<IQueryable<TEntity>> All(bool allAll = false)
        {
            return await Task.Run(() =>
            {
                var records = DataSet.AsQueryable();


                return records;
            });
        }
        public virtual async Task<IQueryable<TEntity>> Get(int id)
        {
            return await Task.Run(() =>
            {
                var records = DataSet.AsQueryable();

                records = records.Where(x => x.Id == id);
                return records;
            });
        }
        public DbContext GetContext()
        {
            throw new NotImplementedException();
        }

        public Type GetEntityType()
        {
            throw new NotImplementedException();
        }

        public object GetId(TEntity model)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<TEntity> Insert(TEntity entity)
        {
            await DataSet.AddAsync(entity);
            await SaveChanges();
            return entity;
        }
        public virtual async Task<TEntity> Update(TEntity entity)
        {
            DataSet.Update(entity);
            await SaveChanges();
            return entity;
        }

        public virtual async Task SaveChanges()
        {
            try
            {
                Context.ChangeTracker.DetectChanges();
                await Context.SaveChangesAsync();
            }
            catch
            {
                var changedEntries = Context.ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted).ToList();

                foreach (var entry in changedEntries)
                {
                    entry.State = EntityState.Detached;
                }

                throw;
            }
        }
        public IDbContextTransaction BeginTransaction()
        {
            return Context.Database.BeginTransaction();
        }


    }
}
