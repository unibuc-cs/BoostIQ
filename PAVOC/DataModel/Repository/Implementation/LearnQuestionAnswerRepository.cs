using System;
using PAVOC.DataModel.Context;
using PAVOC.DataModel.Models;
using PAVOC.DataModel.Repository.Interface;

namespace PAVOC.DataModel.Repository.Implementation
{
    public class LearnQuestionAnswerRepository : GenericRepository<LearnQuestionAnswerEntity>, ILearnQuestionAnswerRepository
    {
        public LearnQuestionAnswerRepository(AppDbContext context) : base(context) { }

    }
}
