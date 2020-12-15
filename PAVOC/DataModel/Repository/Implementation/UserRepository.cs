using System;
using System.Linq;
using PAVOC.DataModel.Context;
using PAVOC.DataModel.Models;
using PAVOC.DataModel.Repository.Interface;

namespace PAVOC.DataModel.Repository.Implementation
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public UserEntity GetUserByUsernameAndPassword(string username, string password)
        {
            return _context.Users.Where(p => p.Username == username && p.Password == password).FirstOrDefault();
        }
    }
}
