using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAVOC.Common.DTO
{
    public class LearnQuestionDTO
    {
        public Int32 LearnQuestionEntityId { get; set; }

        public String Text { get; set; }

        public int Order { get; set; }


        public ICollection<LearnQuestionAnswerDTO> LearnQuestionAnswers { get; set; } = new List<LearnQuestionAnswerDTO>();

    }
}
