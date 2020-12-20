using System;
using System.Collections.Generic;
using System.Linq;
using PAVOC.DataModel.Context;
using PAVOC.DataModel.Models;
using PAVOC.DataModel.Repository.Interface;

namespace PAVOC.DataModel.Repository.Implementation
{
    public class TestLevelRepository : GenericRepository<TestLevelEntity>, ITestLevelRepository
    {
        public TestLevelRepository(AppDbContext context) : base(context) { }
        public IEnumerable<TestLevelEntity> GetAll()
        {
            return _context.TestLevels.ToList();

        }

    }
}
