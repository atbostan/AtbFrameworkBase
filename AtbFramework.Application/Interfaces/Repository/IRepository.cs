using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AtbFramework.Domain.Commons;

namespace AtbFramework.Application.Interfaces.Repository
{
    public interface IRepository<TEntity,TPrimaryKey> where TEntity: BaseEntity<TPrimaryKey>, new()
    {
        Task<TEntity> Add(TEntity entity);
        Task HardDelete(TEntity entity);
        Task<TEntity> Find(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> FindForHardDelete(Expression<Func<TEntity, bool>> filter);
        Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}
