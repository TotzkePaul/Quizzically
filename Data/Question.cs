using System;
using System.ComponentModel.DataAnnotations;

namespace Quizzically.Data
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public Guid QuizId { get; set; }
        public string QuestionContent { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
    }
}
