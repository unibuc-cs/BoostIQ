using System;
using System.Collections.Generic;
using PAVOC.DataModel.Models;
namespace PAVOC.DataModel.Repository.Interface
{
    public interface ICategoryRepository : IGenericRepository<CategoryEntity>
    {

        public IEnumerable<CategoryEntity> GetAll();

        
        //public IEnumerable<CategoryEntity> GetCategories();


        public CategoryEntity GetCategoryByName(string name);
    }
}
