using System;
using PAVOC.DataModel.Context;
using PAVOC.DataModel.Models;
using PAVOC.DataModel.Repository.Interface;

namespace PAVOC.DataModel.Repository.Implementation
{
    public class UserTestLevelRepository : GenericRepository<UserTestLevelEntity>, IUserTestLevelRepository
    {
        public UserTestLevelRepository(AppDbContext context) : base(context) { }

    }
}
