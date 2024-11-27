using CastraBus.Application.Entities.Generic;
using CastraBus.Common.Domain.Generic;
using FluentValidation;
using System.Linq.Expressions;

namespace CastraBus.Application.Services.Interface
{
    public interface IServiceAsync<TV, TE> where TV : BaseVm
    {
        Task<DataResult> Insert<V>(TV obj) where V : AbstractValidator<TE>;
        Task<DataResult> Update<V>(TV obj) where V : AbstractValidator<TE>;
        Task<DataResult> Delete(Int64 id);
        Task<TV> GetOne(Int64 id);
        Task<IEnumerable<TV>> Get(Expression<Func<TV, bool>> predicate);
    }
}
