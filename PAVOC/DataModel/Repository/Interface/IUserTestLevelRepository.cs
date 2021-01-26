using System;
using System.Collections.Generic;
using PAVOC.DataModel.Models;
namespace PAVOC.DataModel.Repository.Interface
{
    public interface IUserTestLevelRepository : IGenericRepository<UserTestLevelEntity>
    {
        public IEnumerable<UserTestLevelEntity> Get(int userId, int categoryId);

    }
}
