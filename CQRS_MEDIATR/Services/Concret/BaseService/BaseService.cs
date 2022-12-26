﻿using Azure.Core;
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

            var ent=_dataContext.Set<TEntity>().Find(entity);
            _dataContext.Remove(ent);
            await _dataContext.SaveChangesAsync();

        }

        public async Task<TEntity> GetStudent(Expression<Func<TEntity, bool>> expression)
        {
            
                return await _dataContext.Set<TEntity>().FirstOrDefaultAsync(expression);
            
        }

        public async Task<List<TEntity>> GetStudents(Expression<Func<TEntity, bool>> expression = null)
        {
            
                return expression == null ? await _dataContext.Set<TEntity>().ToListAsync() :
                    await _dataContext.Set<TEntity>().Where(expression).ToListAsync();
            
        }

        public async Task Update(TEntity entity)
        {


            var ent = _dataContext.Set<TEntity>().Find(entity);
             _dataContext.Update(ent);
            await _dataContext.SaveChangesAsync();

        }
    }
}
