using System;
using PAVOC.DataModel.Context;
using PAVOC.DataModel.Models;
using PAVOC.DataModel.Repository.Interface;

namespace PAVOC.DataModel.Repository.Implementation
{
    public class UserLearnLevelRepository : GenericRepository<UserLearnLevelEntity>, IUserLearnLevelRepository
    {
        public UserLearnLevelRepository(AppDbContext context) : base(context) { }

    }
}
