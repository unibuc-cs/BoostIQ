using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAVOC.Common.DTO
{
    public class TestQuestionDTO
    {
       
            public Int32 TestQuestionEntityId { get; set; }

            public String Text { get; set; }

            public int Order { get; set; }


            public ICollection<TestQuestionAnswerDTO> TestQuestionAnswers { get; set; } = new List<TestQuestionAnswerDTO>();

        
    }
}
