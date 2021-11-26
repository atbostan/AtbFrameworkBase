using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AtbFramework.Application.Interfaces.Business;
using AtbFramework.Application.Interfaces.Repository;
using AtbFramework.Domain.Commons;
using AtbFramework.Domain.Commons.Constants.Messages;
using AtbFramework.Domain.Commons.Entity;
using AtbFramework.Domain.Commons.Result;

namespace AtbFramework.Application.Business
{
    public class BaseService<TEntity,TPrimaryKey>:IBaseService<TEntity, TPrimaryKey>  where TEntity : BaseEntity<TPrimaryKey>, new()
    {
        private readonly IRepository<TEntity,TPrimaryKey> _repository;
        public BaseService(IRepository<TEntity, TPrimaryKey> repository)
        {
            _repository = repository;
        }


        public async Task<IResult> Add(TEntity entity)
        {
           var result= await _repository.Add(entity);
           return result==null ? new Result(false, ErrorMessages.CreateMessage) : new Result(true, SuccessMessages.CreateMessage,result);
        }

        public async Task<IResult> Find(TPrimaryKey Id)
        {
            var result = await _repository.Find(x => x.Id.Equals(Id));
            return result == null ? new Result(true, ErrorMessages.GetMessage) : new Result(true, result);
        }

        public async Task<IResult> FindForField(Expression<Func<TEntity, bool>> predicate)
        {
            var result = await _repository.FindForHardDelete(predicate);
            return result == null ? new Result(true, ErrorMessages.GetMessage) : new Result(true, result);
        }

        public async Task<IResult> GetAll()
        {
            var result = await _repository.GetAll();
            return result==null ? new Result(true, ErrorMessages.GetMessage) : new Result(true, result);

        }

        public async Task<IResult> GetAllByField(Expression<Func<TEntity, bool>> predicate)
        {
            var result = await _repository.GetAll(predicate);
            return result == null ? new Result(true, ErrorMessages.GetMessage) : new Result(true, result);
        }

        public async Task<IResult> HardDelete(TEntity entity)
        {
            var result =await _repository.HardDelete(entity);
            return result == 0 ? new Result(false, ErrorMessages.DeleteMessage) : new Result(true,SuccessMessages.DeleteMessage);
        }

        public async Task<IResult> Delete(TEntity entity)
        {
            var result=await _repository.Delete(entity);
            return result == 0 ? new Result(false, ErrorMessages.DeleteMessage) : new Result(true, SuccessMessages.DeleteMessage);
        }

        public async Task<IResult> Update(TEntity entity)
        {
           var result = await _repository.Update(entity);
           return result == null ? new Result(false, ErrorMessages.UpdateMessage) : new Result(true,SuccessMessages.UpdateMessage, result);
        }
    }
}
