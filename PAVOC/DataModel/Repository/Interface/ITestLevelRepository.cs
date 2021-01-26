using System;
using System.Collections;
using System.Collections.Generic;
using PAVOC.DataModel.Models;
namespace PAVOC.DataModel.Repository.Interface
{
    public interface ITestLevelRepository : IGenericRepository<TestLevelEntity>
    {
        public IEnumerable<TestLevelEntity> GetAll();

        public TestLevelEntity Get(int categoryId, int levelNumber);
    }
}
