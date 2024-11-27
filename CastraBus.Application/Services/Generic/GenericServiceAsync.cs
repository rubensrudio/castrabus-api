using AutoMapper;
using CastraBus.Application.Entities.Generic;
using CastraBus.Application.Services.Interface;
using CastraBus.Common.Domain.Concret.Enuns;
using CastraBus.Common.Domain.Generic;
using CastraBus.Common.Util;
using CastraBus.Infra.Data.Entities.Generic;
using CastraBus.Infra.Data.UnitOfWork.Interface;
using FluentValidation;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Serilog;

namespace CastraBus.Application.Services.Generic
{
    public class GenericServiceAsync<TV, TE> : IServiceAsync<TV, TE> where TV : BaseVm where TE : BaseEntity
    {
        protected IUnitOfWork unitOfWork;

        protected readonly IMapper mapper;

        protected ILogger logger;

        public string GetActualAsyncMethodName([CallerMemberName] string name = null) => name;

        public GenericServiceAsync(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (this.unitOfWork == null)
            {
                this.unitOfWork = unitOfWork;
            }
            this.mapper = mapper;
        }

        public GenericServiceAsync(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
        {
            if (this.unitOfWork == null)
            {
                this.unitOfWork = unitOfWork;
            }
            this.mapper = mapper;
            this.logger = logger;
        }

        public virtual async Task<DataResult> Insert<V>(TV obj) where V : AbstractValidator<TE>
        {
            try
            {
                var entity = mapper.Map<TE>(source: obj);
                var result = await unitOfWork.GetRepository<TE>().Insert(entity);
                return new DataResult(ListResultTypeEnum.Success, result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<DataResult> Insert(TV obj)
        {
            try
            {
                var entity = mapper.Map<TE>(source: obj);
                var result = await unitOfWork.GetRepository<TE>().Insert(entity);
                return new DataResult(ListResultTypeEnum.Success, result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<DataResult> Update<V>(TV obj) where V : AbstractValidator<TE>
        {
            try
            {
                var obj1 = mapper.Map<TE>(source: obj);
                await unitOfWork.GetRepository<TE>().Update(obj1);
                return new DataResult(ListResultTypeEnum.Success, "");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<DataResult> Update(TV obj)
        {
            try
            {
                var obj1 = mapper.Map<TE>(source: obj);
                await unitOfWork.GetRepository<TE>().Update(obj1);
                return new DataResult(ListResultTypeEnum.Success, "");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<DataResult> Delete(Int64 id)
        {
            try
            {
                await unitOfWork.GetRepository<TE>().Delete(id);
                return new DataResult(ListResultTypeEnum.Success, "");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<DataResult> GetAll(Paginate paginate = null)
        {
            try
            {
                var entities = await unitOfWork.GetRepository<TE>().GetAll();

                var ret = mapper.Map<IEnumerable<TV>>(source: entities);
                var dataResult = new DataResult
                {
                    ResultType = ListResultTypeEnum.Success,
                    Result = ret,
                    Paginate = paginate
                };
                Console.WriteLine($"DataReslt {dataResult.ResultType} {ret.Count()}");
                return dataResult;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<TV> GetOne(Int64 id)
        {
            try
            {
                var entity = await unitOfWork.GetRepository<TE>().GetOne(id);
                return mapper.Map<TV>(source: entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<IEnumerable<TV>> Get(Expression<Func<TV, bool>> predicate)
        {
            try
            {
                var pr = mapper.Map<Expression<Func<TE, bool>>>(source: predicate);
                var items = await unitOfWork.GetRepository<TE>().Get(pr);
                return mapper.Map<IEnumerable<TV>>(source: items);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<string> Erros { get; } = new List<string>();

        public void AddErro(string menssage)
        {
            Erros.Add(menssage);
        }

        public void InitErros()
        {
            Erros.Clear();
        }

    }
}
