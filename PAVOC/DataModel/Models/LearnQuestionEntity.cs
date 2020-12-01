using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PAVOC.DataModel.Models
{
    public class LearnQuestionEntity
    {
        public Int32 LearnQuestionEntityId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public String Text { get; set; }

        public int Order { get; set; }

        public int LearnLevelEntityId { get; set; }
        public LearnLevelEntity LearnLevelEntity { get; set; }

        public ICollection<LearnQuestionAnswerEntity> LearnQuestionAnswers { get; set; } = new List<LearnQuestionAnswerEntity>();

    }
}
