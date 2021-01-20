using System;
using System.Collections.Generic;
using PAVOC.DataModel.Models;
namespace PAVOC.DataModel.Repository.Interface
{
    public interface IUserLearnLevelRepository : IGenericRepository<UserLearnLevelEntity>
    {
        public IEnumerable<UserLearnLevelEntity> Get(int userId, int categoryId);
    }
}
