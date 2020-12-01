using System;
using PAVOC.DataModel.Context;
using PAVOC.DataModel.Models;
using PAVOC.DataModel.Repository.Interface;

namespace PAVOC.DataModel.Repository.Implementation
{
    public class TestQuestionAnswerRepository : GenericRepository<TestQuestionAnswerEntity>, ITestQuestionAnswerRepository
    {
        public TestQuestionAnswerRepository(AppDbContext context) : base(context) { }

    }
}
