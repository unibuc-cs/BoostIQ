using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PAVOC.DataModel.Context;
using PAVOC.DataModel.Models;
using PAVOC.DataModel.Repository.Interface;

namespace PAVOC.DataModel.Repository.Implementation
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public IEnumerable<UserEntity> GetAll()
        {
            return _context.Users.Include(p => p.UserLearnLevels).Include(p => p.UserTestLevels).ToList();
        }

        public UserEntity GetUserByUsernameAndPassword(string username, string password)
        {
            return _context.Users.Where(p => p.Username == username && p.Password == password).FirstOrDefault();
        }
    }
}
