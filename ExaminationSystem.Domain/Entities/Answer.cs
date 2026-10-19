using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem.Domain.Entities
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }

        public Answer(int answerId,string answerText)
        {
            AnswerId = answerId;
            AnswerText = answerText;
        }
    }
}
