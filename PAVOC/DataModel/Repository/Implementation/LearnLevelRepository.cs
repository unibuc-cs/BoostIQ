using System;
using System.Collections.Generic;
using System.Linq;
using PAVOC.DataModel.Context;
using PAVOC.DataModel.Models;
using PAVOC.DataModel.Repository.Interface;

namespace PAVOC.DataModel.Repository.Implementation
{
    public class LearnLevelRepository : GenericRepository<LearnLevelEntity>, ILearnLevelRepository
    {
        public LearnLevelRepository(AppDbContext context) : base(context) { }

        public IEnumerable<LearnLevelEntity> GetAll()
        {
            return _context.LearnLevels.ToList();
            
        }
    }
}
