using CQRS_MEDIATR.Model;
using System.Linq.Expressions;

namespace CQRS_MEDIATR.Services.Abstract.BaseService
{
    public interface IBaseService<T> 
    {
        Task<T> Get(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAll(Expression<Func<T, bool>> expression = null);
        Task Add(T entity);
        Task Delete(T entity);
        Task Update(T entity);

    }
}
