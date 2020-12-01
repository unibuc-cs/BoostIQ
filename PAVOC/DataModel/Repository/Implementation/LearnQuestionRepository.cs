using System;
using PAVOC.DataModel.Context;
using PAVOC.DataModel.Models;
using PAVOC.DataModel.Repository.Interface;

namespace PAVOC.DataModel.Repository.Implementation
{
    public class LearnQuestionRepository : GenericRepository<LearnQuestionEntity>, ILearnQuestionRepository
    {
        public LearnQuestionRepository(AppDbContext context) : base(context) { }

    }
}
