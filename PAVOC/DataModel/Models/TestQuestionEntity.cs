using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PAVOC.DataModel.Models
{
    public class TestQuestionEntity
    {
        public Int32 TestQuestionEntityId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public String Text { get; set; }

        public int Order { get; set; }

        public int TestLevelEntityId { get; set; }
        public TestLevelEntity TestLevelEntity { get; set; }

        public ICollection<TestQuestionAnswerEntity> TestQuestionAnswers { get; set; } = new List<TestQuestionAnswerEntity>();

    }
}
