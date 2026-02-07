using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizExamSystem.Models
{
    public class ExamResults
    {
        public int ResultId { get; set; }
        public int UserId { get; set; }
        public int ExamId { get; set; }
        public double Score { get; set; }
    }
}
