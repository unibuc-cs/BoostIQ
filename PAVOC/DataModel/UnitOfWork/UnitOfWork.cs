using System;
using System.Collections.Generic;
using PAVOC.DataModel.Context;
using PAVOC.DataModel.Repository.Implementation;
using PAVOC.DataModel.Repository.Interface;

namespace PAVOC.DataModel.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _dbContext;

        private readonly IDictionary<string, IRepository> _specificRepositories = new Dictionary<string, IRepository>();

        public UnitOfWork()
        {
            _dbContext = new AppDbContext();

        }


        public int Save()
        {
            return _dbContext.SaveChanges();
        }


        public T GetRepository<T>() where T : IRepository
        {
            var key = typeof(T).Name;
            if (!_specificRepositories.ContainsKey(key))
            {
                _specificRepositories[key] = CreateRepository<T>();
            }
            return (T)_specificRepositories[key];
        }

        private IRepository CreateRepository<TEntity>() where TEntity : IRepository
        {
            //TODO Petros -> add here non-generic repositories
            return null;
        }

        #region Memory management

        // To detect redundant calls
        private bool _disposed = false;


        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose() => Dispose(true);

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // Dispose managed state (managed objects).
                _dbContext.Dispose();
            }

            _disposed = true;
        }
        #endregion
    }
}
