using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PAVOC.DataModel.Models
{
    public class TestLevelEntity
    {
        public Int32 TestLevelEntityId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public String Text { get; set; }

        [Required(AllowEmptyStrings = false)]
        public String Image { get; set; }

        public int TestLevelNumber { get; set; }

        public int CategoryEntityId { get; set; }

        public CategoryEntity Category { get; set; }


        public ICollection<TestQuestionEntity> TestQuestions { get; set; } = new List<TestQuestionEntity>();

        public IList<UserTestLevelEntity> UserTestLevels { get; set; } = new List<UserTestLevelEntity>();
    }
}
