using System;
using PAVOC.DataModel.Models;
namespace PAVOC.DataModel.Repository.Interface
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {
        public UserEntity GetUserByUsernameAndPassword(string username, string password);
    }
}
