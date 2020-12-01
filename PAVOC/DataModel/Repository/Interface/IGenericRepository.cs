using System;
namespace PAVOC.DataModel.Repository.Interface
{
    public interface IGenericRepository<TEntity> : IRepository where TEntity : class
    {
        TEntity GetById(object id);

        void Add(TEntity entity);

        void Delete(object id);

        void Delete(TEntity entity);

        TEntity Update(TEntity entity);

    }
}
