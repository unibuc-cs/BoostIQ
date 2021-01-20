using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PAVOC.DataModel.Context;
using PAVOC.DataModel.Models;
using PAVOC.DataModel.Repository.Interface;

namespace PAVOC.DataModel.Repository.Implementation
{
    public class LearnLevelRepository : GenericRepository<LearnLevelEntity>, ILearnLevelRepository
    {
        public LearnLevelRepository(AppDbContext context) : base(context) { }

        public IEnumerable<LearnLevelEntity> GetAll()
        {
            return _context.LearnLevels
                .Include(p=>p.Category)
                .Include(p=>p.LearnQuestions).ThenInclude(z=> z.LearnQuestionAnswers)
                .ToList();
            
        }

        public LearnLevelEntity Get(int categoryId, int levelNumber)
        {
            return _context.LearnLevels
                .Include(p => p.LearnQuestions).ThenInclude(z => z.LearnQuestionAnswers)
                .Where(p => p.CategoryEntityId == categoryId && p.LearnLevelNumber == levelNumber).FirstOrDefault();
        }
    }
}
