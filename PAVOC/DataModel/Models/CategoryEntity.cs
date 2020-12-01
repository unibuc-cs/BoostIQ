using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PAVOC.DataModel.Models
{
    public class CategoryEntity
    {
        public Int32 CategoryEntityId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        public String Name { get; set; }

        public ICollection<LearnLevelEntity> LearnLevels { get; set; } = new List<LearnLevelEntity>();

    }
}
