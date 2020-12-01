using System;
namespace PAVOC.DataModel.UnitOfWork
{
    interface IUnitOfWork : IDisposable
    {
        public int Save();
    }
}
