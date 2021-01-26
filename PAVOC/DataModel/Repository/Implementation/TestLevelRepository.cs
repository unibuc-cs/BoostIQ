using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PAVOC.DataModel.Context;
using PAVOC.DataModel.Models;
using PAVOC.DataModel.Repository.Interface;

namespace PAVOC.DataModel.Repository.Implementation
{
    public class TestLevelRepository : GenericRepository<TestLevelEntity>, ITestLevelRepository
    {
        public TestLevelRepository(AppDbContext context) : base(context) { }

        public IEnumerable<TestLevelEntity> GetAll()
        {
            return _context.TestLevels
                .Include(p => p.Category)
                .Include(p => p.TestQuestions).ThenInclude(z => z.TestQuestionAnswers)
                .ToList();

        }

        public TestLevelEntity Get(int categoryId, int levelNumber)
        {
            return _context.TestLevels
                .Include(p => p.TestQuestions).ThenInclude(z => z.TestQuestionAnswers)
                .Where(p => p.CategoryEntityId == categoryId && p.TestLevelNumber == levelNumber).FirstOrDefault();
        }
    }
}
