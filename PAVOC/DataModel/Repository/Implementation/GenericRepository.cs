using System;
using Microsoft.EntityFrameworkCore;
using PAVOC.DataModel.Context;
using PAVOC.DataModel.Repository.Interface;

namespace PAVOC.DataModel.Repository.Implementation
{
    public class GenericRepository<TEntity> : IRepository, IGenericRepository<TEntity> where TEntity : class
    {
        protected AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            this._context = context;
            this._dbSet = context.Set<TEntity>();
        }


        public virtual TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public virtual void Delete(object id)
        {
            throw new ApplicationException("No phisical deletion in this app. Use IsDeleted property instead.");
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            throw new ApplicationException("No phisical deletion in this app. Use IsDeleted property instead.");
        }

        public TEntity Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            return entity;
        }

    }
}
