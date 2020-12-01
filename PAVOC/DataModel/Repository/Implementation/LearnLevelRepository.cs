using System;
using PAVOC.DataModel.Context;
using PAVOC.DataModel.Models;
using PAVOC.DataModel.Repository.Interface;

namespace PAVOC.DataModel.Repository.Implementation
{
    public class LearnLevelRepository : GenericRepository<LearnLevelEntity>, ILearnLevelRepository
    {
        public LearnLevelRepository(AppDbContext context) : base(context) { }

    }
}
