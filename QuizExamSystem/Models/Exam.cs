using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizExamSystem.Models
{
    public class Exam
    {
        public int ExamId { get; set; }
        public int SubjectId { get; set; }
        public DateTime ExamDate { get; set; }
    }
}
