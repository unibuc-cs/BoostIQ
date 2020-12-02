using System;
using PAVOC.DataModel.Models;
using PAVOC.DataModel.Repository.Interface;

namespace PAVOC.DataModel.DbManager
{
    public class UserDbManager
    {
        public static UserEntity GetUser(int id)
        {
            using (var uow = new UnitOfWork.UnitOfWork())
            {
                var repo = uow.GetRepository<IUserRepository>();

                return repo.GetById(id);
            }
        }
    }
}
