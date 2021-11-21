using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AtbFramework.Domain.Commons;

namespace AtbFramework.Application.Interfaces.Repository
{
    public interface IRepository<TEntity,TPrimaryKey> where TEntity:BaseEntity<TPrimaryKey> , new()
    {
        void Add(TEntity entity);
        void HardDelete(TEntity entity);
        TEntity Find(Expression<Func<TEntity, bool>> filter);
        TEntity FindForHardDelete(Expression<Func<TEntity, bool>> filter);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
