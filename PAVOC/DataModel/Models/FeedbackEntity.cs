using System;
using System.ComponentModel.DataAnnotations;

namespace PAVOC.DataModel.Models
{
    public class FeedbackEntity
    {
        public Int32 FeedbackEntityId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public String Message { get; set; }

        public int UserEntityId { get; set; }
        public UserEntity User { get; set; }
    }
}
