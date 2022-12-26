using Azure.Core;
using CQRS_MEDIATR.Data;
using CQRS_MEDIATR.Model;
using CQRS_MEDIATR.Services.Abstract.BaseService;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CQRS_MEDIATR.Services.Concret.BaseService
{
    public class BaseService<TContext, TEntity> : IBaseService<TEntity>
        where TContext : DbContext, new()
        where TEntity : class, new()

    {
        public async Task Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Entry(entity).State = EntityState.Added;
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Entry(entity).State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }

        public Task<TEntity> GetStudent(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TEntity>> GetStudents(Expression<Func<TEntity, bool>> expression = null)
        {
            using (TContext context = new TContext())
            {
                return expression == null ? await context.:
                    await context.Set<TEntity>.Where(expression).ToListAsync();
            }
        }

        public async Task Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
    }
}
