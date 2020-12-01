using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PAVOC.DataModel.Models
{
    public class UserEntity
    {
        public Int32 UserEntityId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        public String Username { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        public String Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        public String Password { get; set; }

        public Int32 PointsLearn { get; set; }

        public Int32 PointsPlay { get; set; }

        public ICollection<FeedbackEntity> Feedbacks { get; set; } = new List<FeedbackEntity>();

        public IList<UserLearnLevelEntity> UserLearnLevels { get; set; } = new List<UserLearnLevelEntity>();
        public IList<UserTestLevelEntity> UserTestLevels { get; set; } = new List<UserTestLevelEntity>();
    }
}
