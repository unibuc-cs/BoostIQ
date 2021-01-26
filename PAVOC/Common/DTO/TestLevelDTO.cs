using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAVOC.Common.DTO
{
    public class TestLevelDTO
    {
        public Int32 TestLevelEntityId { get; set; }


        public String Text { get; set; }


        public String Image { get; set; }

        public int TestLevelNumber { get; set; }


        public ICollection<TestQuestionDTO> TestQuestions { get; set; } = new List<TestQuestionDTO>();

    }
}
