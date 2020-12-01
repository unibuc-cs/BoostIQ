using System;
using PAVOC.DataModel.Context;
using PAVOC.DataModel.Models;
using PAVOC.DataModel.Repository.Interface;

namespace PAVOC.DataModel.Repository.Implementation
{
    public class TestQuestionRepository : GenericRepository<TestQuestionEntity>, ITestQuestionRepository
    {
        public TestQuestionRepository(AppDbContext context) : base(context) { }

    }
}
