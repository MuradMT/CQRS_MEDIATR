using Azure.Core;
using CQRS_MEDIATR.Data;
using CQRS_MEDIATR.Model;
using CQRS_MEDIATR.Services.Abstract.BaseService;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CQRS_MEDIATR.Services.Concret.BaseService
{
    public class BaseService<TEntity> : IBaseService<TEntity>
        where TEntity : class, new()

    {
        private DataContext _dataContext;
        public BaseService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task Add(TEntity entity)
        {
            await _dataContext.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {


            _dataContext.Remove(entity);
            await _dataContext.SaveChangesAsync();

        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> expression)
        {

            return await _dataContext.Set<TEntity>().FirstOrDefaultAsync(expression);

        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression = null)
        {

            return expression == null ? await _dataContext.Set<TEntity>().ToListAsync() :
                await _dataContext.Set<TEntity>().Where(expression).ToListAsync();

        }

        public async Task Update(TEntity entity)
        {
            _dataContext.Update(entity);
            await _dataContext.SaveChangesAsync();
        }
    }
}
