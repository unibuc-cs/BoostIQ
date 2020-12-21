using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAVOC.Common.DTO
{
    public class LearnQuestionAnswerDTO
    {

        public Int32 LearnQuestionAnswerEntityId { get; set; }

 
        public String Text { get; set; }

        public Boolean IsCorrect { get; set; }

    }
}
