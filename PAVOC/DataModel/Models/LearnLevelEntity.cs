using System;
using System.ComponentModel.DataAnnotations;

namespace PAVOC.DataModel.Models
{
    public class LearnLevelEntity
    {
        public Int32 LearnLevelEntityId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public String Text { get; set; }

        [Required(AllowEmptyStrings = false)]
        public String Image { get; set; }

        public int LearnLevelNumber { get; set; }

        public int CategoryEntityId { get; set; }
        public CategoryEntity Category { get; set; }
    }
}
