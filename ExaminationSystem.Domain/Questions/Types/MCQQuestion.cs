using ExaminationSystem.Domain.Entities;
using ExaminationSystem.Domain.Questions.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem.Domain.Questions.Types
{
    internal class MCQQuestion : Question
    {
        public MCQQuestion(string header, string body, int mark, Answer[] answerList, Answer rightAnswer): base(header, body, mark, answerList, rightAnswer)
        {
        }
    }
}
