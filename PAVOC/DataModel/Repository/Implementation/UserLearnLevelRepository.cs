using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PAVOC.DataModel.Context;
using PAVOC.DataModel.Models;
using PAVOC.DataModel.Repository.Interface;

namespace PAVOC.DataModel.Repository.Implementation
{
    public class UserLearnLevelRepository : GenericRepository<UserLearnLevelEntity>, IUserLearnLevelRepository
    {
        public UserLearnLevelRepository(AppDbContext context) : base(context) { }

        public IEnumerable<UserLearnLevelEntity> Get(int userId, int categoryId)
        {
            return _context.UserLearnLevels.Include(p => p.LearnLevel)
                .Where(p => p.UserEntityId == userId && p.LearnLevel.CategoryEntityId == categoryId).ToList();
        }


    }
}
