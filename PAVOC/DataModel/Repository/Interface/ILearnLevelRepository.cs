using System;
using System.Collections;
using System.Collections.Generic;
using PAVOC.DataModel.Models;
namespace PAVOC.DataModel.Repository.Interface
{
    public interface ILearnLevelRepository : IGenericRepository<LearnLevelEntity>
    {
        public IEnumerable<LearnLevelEntity> GetAll();

        public LearnLevelEntity Get(int categoryId, int levelNumber);
    }
}
