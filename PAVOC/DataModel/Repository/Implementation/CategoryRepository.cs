using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PAVOC.DataModel.Context;
using PAVOC.DataModel.Models;
using PAVOC.DataModel.Repository.Interface;

namespace PAVOC.DataModel.Repository.Implementation
{
    public class CategoryRepository : GenericRepository<CategoryEntity>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context) { }

        public IEnumerable<CategoryEntity> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public CategoryEntity GetCategoryByName(string name)
        {
            return _context.Categories.Where(p => p.Name == name)
                .Include(p => p.LearnLevels)
                .Include(p => p.TestLevels)
                .FirstOrDefault();
                
        }

    }
}
