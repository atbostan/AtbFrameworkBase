using AtbFramework.Application.DTOs;
using AtbFramework.Application.Interfaces.Business;
using AtbFramework.Application.Interfaces.DTO;
using AtbFramework.Application.Interfaces.Repository;
using AtbFramework.Domain.Commons.Constants.Messages;
using AtbFramework.Domain.Commons.Entity;
using AtbFramework.Domain.Commons.Result;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AtbFramework.Application.Business
{
    public class BaseService<TEntity, TPrimaryKey, TEntityDto> : IBaseService<TEntity, TPrimaryKey, TEntityDto> where TEntity : BaseEntity<TPrimaryKey>, new()
    where TEntityDto : IDto
    {
        private readonly IRepository<TEntity, TPrimaryKey> _repository;
        private readonly IMapper _mapper;
        public BaseService(IRepository<TEntity, TPrimaryKey> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<IResult> Add(TEntityDto entityDto)
        {
            var entity = _mapper.Map<TEntity>(entityDto);
            var result = await _repository.Add(entity);
            return result == null ? new Result(false, ErrorMessages.CreateMessage) : new Result(true, SuccessMessages.CreateMessage.Select(c => c.ToString()).ToList(), result.Id);


        }


        public async Task<IResult> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            var result = predicate == null ? await _repository.GetAll() : await _repository.GetAll(predicate);
            return result == null ? new Result(true, ErrorMessages.GetMessage) : 
                result.Count==1 ? new Result(true, SuccessMessages.ReadMessage.Select(c => c.ToString()).ToList(), _mapper.Map<ExampleDto>(result.SingleOrDefault())):new Result(true, _mapper.Map<List<ExampleDto>>(result));

        }

        public async Task<IResult> HardDelete(TPrimaryKey Id)
        {
            var entity = await _repository.Find(x => x.Id.Equals(Id));
            var result =  _repository.HardDelete(entity).IsCompletedSuccessfully;
            return result == false ? new Result(false, ErrorMessages.DeleteMessage) : new Result(true, SuccessMessages.DeleteMessage);
        }

        public async Task<IResult> Delete(TPrimaryKey Id)
        {
            var entity = await _repository.Find(x => x.Id.Equals(Id));
            var result =  _repository.Delete(entity).IsCompletedSuccessfully;
            return result == false? new Result(false, ErrorMessages.DeleteMessage) : new Result(true, SuccessMessages.DeleteMessage);
        }

        public async Task<IResult> Update(TEntityDto entityDto)
        {
            var entity = _mapper.Map<TEntity>(entityDto);
            var result = await _repository.Update(entity);
            return result == null ? new Result(false, ErrorMessages.UpdateMessage) : new Result(true, SuccessMessages.UpdateMessage.Select(c => c.ToString()).ToList(), result.Id);
        }
    }
}
