using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quizzically.Data
{
    public class Answer
    {
        [Key]
        public Guid QuestionId { get; set; }

        public bool IsOption1 { get; set; }
        public bool IsOption2 { get; set; }
        public bool IsOption3 { get; set; }
        public bool IsOption4 { get; set; }
    }
}
