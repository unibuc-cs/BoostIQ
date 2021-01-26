using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PAVOC.DataModel.Context;
using PAVOC.DataModel.Models;
using PAVOC.DataModel.Repository.Interface;

namespace PAVOC.DataModel.Repository.Implementation
{
    public class UserTestLevelRepository : GenericRepository<UserTestLevelEntity>, IUserTestLevelRepository
    {
        public UserTestLevelRepository(AppDbContext context) : base(context) { }

        public IEnumerable<UserTestLevelEntity> Get(int userId, int categoryId)
        {
            return _context.UserTestLevels.Include(p => p.TestLevel)
                .Where(p => p.UserEntityId == userId && p.TestLevel.CategoryEntityId == categoryId).ToList();
        }


    }
}
