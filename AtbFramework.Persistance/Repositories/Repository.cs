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
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void HardDelete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Remove(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Find(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().Where(x => x.IsDeleted == false).SingleOrDefault(filter);
            }
        }

        public TEntity FindForHardDelete(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().Where(x => x.IsDeleted == false).ToList() : context.Set<TEntity>().Where(x => x.IsDeleted == false).Where(filter).ToList(); //Eğer filter null'sa direk hepsini getir yoksa(:) filtre uygula
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                entity.ModificationTime = DateTime.Now;
                var updatedEntities = context.Update(entity);
                updatedEntities.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                entity.IsDeleted = true;
                entity.DeletionTime = DateTime.Now;
                var updatedEntities = context.Update(entity);
                updatedEntities.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
