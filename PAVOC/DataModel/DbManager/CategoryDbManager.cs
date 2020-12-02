using System;
using System.Collections.Generic;
using PAVOC.DataModel.Models;
using PAVOC.DataModel.Repository.Interface;

namespace PAVOC.DataModel.DbManager
{
    public class CategoryDbManager
    {
        public static IEnumerable<CategoryEntity> GetCategories()
        {
            using (var uow = new UnitOfWork.UnitOfWork())
            {
                var repo = uow.GetRepository<ICategoryRepository>();

                return repo.GetCategories();
            }
        }
    }
}
