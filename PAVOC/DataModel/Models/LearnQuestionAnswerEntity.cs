using System;
using System.ComponentModel.DataAnnotations;

namespace PAVOC.DataModel.Models
{
    public class LearnQuestionAnswerEntity
    {
        public Int32 LearnQuestionAnswerEntityId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public String Text { get; set; }

        public Boolean IsCorrect { get; set; }

        public int LearnQuestionEntityId { get; set; }
        public LearnQuestionEntity LearnQuestion { get; set; }
    }
}
