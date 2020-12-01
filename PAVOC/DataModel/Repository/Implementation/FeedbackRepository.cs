using System;
using PAVOC.DataModel.Context;
using PAVOC.DataModel.Models;
using PAVOC.DataModel.Repository.Interface;

namespace PAVOC.DataModel.Repository.Implementation
{
    public class FeedbackRepository : GenericRepository<FeedbackEntity>, IFeedbackRepository
    {
        public FeedbackRepository(AppDbContext context) : base(context) { }

    }
}
