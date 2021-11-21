using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AtbFramework.Domain.Commons;

namespace AtbFramework.Application.Interfaces.Business
{
    public interface IBaseService<TEntity, TPrimaryKey> where TEntity : BaseEntity<TPrimaryKey>, new()
    {
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Find(TPrimaryKey Id);
        Task<TEntity> FindForField(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> GetAll();
        Task<List<TEntity>> GetAllByField(Expression<Func<TEntity, bool>> predicate);
        Task HardDelete(TEntity entity);
        Task Delete(TEntity entity);
        Task<TEntity> Update(TEntity entity);


    }
}
