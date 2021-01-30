using System;
using System.Collections.Generic;
using PAVOC.DataModel.Models;
namespace PAVOC.DataModel.Repository.Interface
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {
        public IEnumerable<UserEntity> GetAll();

        public UserEntity GetUserByUsernameAndPassword(string username, string password);
    }
}
