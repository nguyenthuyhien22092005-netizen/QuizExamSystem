using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizExamSystem.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public int SubjectId { get; set; }
        public string Content { get; set; }
        public string CorrectAnswer { get; set; }
    }
}
