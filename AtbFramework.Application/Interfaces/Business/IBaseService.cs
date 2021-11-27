using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AtbFramework.Application.Interfaces.DTO;
using AtbFramework.Domain.Commons;
using AtbFramework.Domain.Commons.Entity;
using AtbFramework.Domain.Commons.Result;

namespace AtbFramework.Application.Interfaces.Business
{
    public interface IBaseService<TEntity, TPrimaryKey, TEntityDto> where TEntity : BaseEntity<TPrimaryKey>, new()
    where TEntityDto : IDto
    {
        Task<IResult> Add(TEntityDto entityDto);
        Task<IResult> Find(Expression<Func<TEntity, bool>> predicate);
        Task<IResult> GetAll(Expression<Func<TEntity, bool>> predicate = null);
        Task<IResult> HardDelete(TPrimaryKey Id);
        Task<IResult> Delete(TPrimaryKey Id);
        Task<IResult> Update(TEntityDto entityDto);


    }
}
