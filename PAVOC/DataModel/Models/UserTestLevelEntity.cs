using System;
namespace PAVOC.DataModel.Models
{
    public class UserTestLevelEntity
    {
        public Int32 UserEntityId { get; set; }
        public UserEntity User { get; set; }

        public Int32 TestLevelEntityId { get; set; }
        public TestLevelEntity TestLevel { get; set; }
    }
}
