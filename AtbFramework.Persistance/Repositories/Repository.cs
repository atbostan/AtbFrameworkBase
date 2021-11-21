using AtbFramework.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AtbFramework.Domain.Commons;
using Microsoft.EntityFrameworkCore;

namespace AtbFramework.Persistance.Repositories
{
    public class Repository<TEntity,TContext,TPrimaryKey>  : IRepository<TEntity, TPrimaryKey> 
        where TEntity:BaseEntity<TPrimaryKey>,new()
        where TContext: DbContext , new()
    {
        public async Task<TEntity> Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity =  context.Entry(entity);
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
                return addedEntity.Entity;
            }
        }

        public async Task HardDelete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Remove(entity);
                deletedEntity.State = EntityState.Deleted;
                await context.SaveChangesAsync();
            } 
        }

        public async Task<TEntity> Find(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return await context.Set<TEntity>().Where(x => x.IsDeleted == false).SingleOrDefaultAsync(filter);
            }
        }

        public async Task<TEntity> FindForHardDelete(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
            }
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return  filter == null ? await context.Set<TEntity>().Where(x => x.IsDeleted == false).ToListAsync() : await context.Set<TEntity>().Where(x => x.IsDeleted == false).Where(filter).ToListAsync(); 
            }
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                entity.ModificationTime = DateTime.Now;
                var updatedEntities = context.Update(entity);
                updatedEntities.State = EntityState.Modified;
                await  context.SaveChangesAsync();
                return updatedEntities.Entity;
            }
        }

        public async Task Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                entity.IsDeleted = true;
                entity.DeletionTime = DateTime.Now;
                var updatedEntities = context.Update(entity);
                updatedEntities.State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
    }
}
