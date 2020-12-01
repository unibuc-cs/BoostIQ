using System;
namespace PAVOC.DataModel.Models
{
    public class UserLearnLevelEntity
    {
        public Int32 UserEntityId { get; set; }
        public UserEntity User { get; set; }

        public Int32 LearnLevelEntityId { get; set; }
        public LearnLevelEntity LearnLevel { get; set; }
    }
}
