using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AtbFramework.Application.Interfaces.Business;
using AtbFramework.Application.Interfaces.Repository;
using AtbFramework.Domain.Commons;

namespace AtbFramework.Application.Business
{
    public class BaseService<TEntity,TPrimaryKey>:IBaseService<TEntity, TPrimaryKey>  where TEntity : BaseEntity<TPrimaryKey>, new()
    {
        private readonly IRepository<TEntity,TPrimaryKey> _repository;
        public BaseService(IRepository<TEntity, TPrimaryKey> repository)
        {
            _repository = repository;
        }


        public async Task<TEntity> Add(TEntity entity)
        {
           var result= await _repository.Add(entity);
            return result;
        }

        public async Task<TEntity> Find(TPrimaryKey Id)
        {
            var result = await _repository.Find(x => x.Id.Equals(Id));
            return result;
        }

        public async Task<TEntity> FindForField(Expression<Func<TEntity, bool>> predicate)
        {
            var result = await _repository.FindForHardDelete(predicate);
            return result;
        }

        public async Task<List<TEntity>> GetAll()
        {
            var result = await _repository.GetAll();
            return result;

        }

        public async Task<List<TEntity>> GetAllByField(Expression<Func<TEntity, bool>> predicate)
        {
            var result = await _repository.GetAll(predicate);
            return result;
        }

        public async Task HardDelete(TEntity entity)
        {
            await _repository.HardDelete(entity);
        }

        public async Task Delete(TEntity entity)
        {
            await _repository.Delete(entity);
        }

        public async Task<TEntity> Update(TEntity entity)
        {
           var result = await _repository.Update(entity);
           return result;
        }
    }
}
