using System;
namespace PAVOC.DataModel.Models
{
    public class UserTestQuestionEntity
    {
        public Int32 UserEntityId { get; set; }
        public UserEntity User { get; set; }

        public Int32 TestQuestionEntityId { get; set; }
        public TestLevelEntity TestQuestion { get; set; }
    }
}
