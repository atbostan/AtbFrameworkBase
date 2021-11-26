using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AtbFramework.Domain.Commons;
using AtbFramework.Domain.Commons.Entity;
using AtbFramework.Domain.Commons.Result;

namespace AtbFramework.Application.Interfaces.Business
{
    public interface IBaseService<TEntity, TPrimaryKey> where TEntity : BaseEntity<TPrimaryKey>, new()
    {
        Task<IResult> Add(TEntity entity);
        Task<IResult> Find(TPrimaryKey Id);
        Task<IResult> FindForField(Expression<Func<TEntity, bool>> predicate);
        Task<IResult> GetAll();
        Task<IResult> GetAllByField(Expression<Func<TEntity, bool>> predicate);
        Task<IResult> HardDelete(TEntity entity);
        Task<IResult> Delete(TEntity entity);
        Task<IResult> Update(TEntity entity);


    }
}
