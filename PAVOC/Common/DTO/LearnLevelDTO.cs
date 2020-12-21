using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAVOC.Common.DTO
{
    public class LearnLevelDTO
    {
        public Int32 LearnLevelEntityId { get; set; }

        
        public String Text { get; set; }

        
        public String Image { get; set; }

        public int LearnLevelNumber { get; set; }


        public ICollection<LearnQuestionDTO> LearnQuestions { get; set; } = new List<LearnQuestionDTO>();
        



    }
}
