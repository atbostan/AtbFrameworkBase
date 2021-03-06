using AtbFramework.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AtbFramework.Domain.Commons;
using AtbFramework.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using AtbFramework.Domain.Commons.Entity;

namespace AtbFramework.Persistance.Repositories
{
    public class Repository<TEntity,TPrimaryKey>  : IRepository<TEntity, TPrimaryKey> 
        where TEntity:BaseEntity<TPrimaryKey>,new()
    {

        protected readonly DbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;

        }

        public async Task<TEntity> Add(TEntity entity)
        {
           
                var addedEntity = _context.Entry(entity);
                addedEntity.State = EntityState.Added;
                await _context.SaveChangesAsync();
                await _context.DisposeAsync();
                return addedEntity.Entity;
            
        }

        public async Task<int> HardDelete(TEntity entity)
        {
           
                var deletedEntity = _context.Remove(entity);
                deletedEntity.State = EntityState.Deleted;
                var result=await _context.SaveChangesAsync();
                await _context.DisposeAsync();
                return result;

        }

        public async Task<TEntity> Find(Expression<Func<TEntity, bool>> filter=null)
        {
                return await _context.Set<TEntity>().Where(x => x.IsDeleted == false || x.IsDeleted == null).SingleOrDefaultAsync(filter);
        }

        public async Task<TEntity> FindForHardDelete(Expression<Func<TEntity, bool>> filter)
        {
                return await _context.Set<TEntity>().SingleOrDefaultAsync(filter);
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
           
                return  filter == null ? await _context.Set<TEntity>().Where(x => x.IsDeleted == false||x.IsDeleted==null).ToListAsync() : await _context.Set<TEntity>().Where(x => x.IsDeleted == false).Where(filter).ToListAsync(); 
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            
                entity.ModificationTime = DateTime.Now;
                var updatedEntities = _context.Update(entity);
                updatedEntities.State = EntityState.Modified;
                await _context.SaveChangesAsync();
                await _context.DisposeAsync();
                return updatedEntities.Entity;
        }

        public async Task<int> Delete(TEntity entity)
        {
           
                entity.IsDeleted = true;
                entity.DeletionTime = DateTime.Now;
                var updatedEntities = _context.Update(entity);
                updatedEntities.State = EntityState.Modified;
                var result =await _context.SaveChangesAsync();
                await _context.DisposeAsync();
                return result;

        }
    }
}
