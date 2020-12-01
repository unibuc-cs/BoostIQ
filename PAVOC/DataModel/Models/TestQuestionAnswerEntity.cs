using System;
using System.ComponentModel.DataAnnotations;

namespace PAVOC.DataModel.Models
{
    public class TestQuestionAnswerEntity
    {
        public Int32 TestQuestionAnswerEntityId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public String Text { get; set; }

        public Boolean IsCorrect { get; set; }

        public int TestQuestionEntityId { get; set; }
        public TestQuestionEntity TestQuestion { get; set; }
    }
}
