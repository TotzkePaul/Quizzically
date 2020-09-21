using System;
using System.ComponentModel.DataAnnotations;

namespace Quizzically.Data
{
    public class Quiz
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }

        public string OwnerId { get; set; }
    }
}
