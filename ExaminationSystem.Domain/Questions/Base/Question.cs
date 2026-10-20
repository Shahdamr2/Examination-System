using System;
using System.Linq;
using ExaminationSystem.Domain.Entities;
namespace ExaminationSystem.Domain.Questions.Base

{
    public abstract class Question
    {
        public string Header { get; set; } = default;
        public string Body { get; set; } = default;
        public int Mark { get; set; }
        public Answer[]? AnswerList { get; set; }
        public Answer? RightAnswer { get; set; }
        protected Question(string header, string body, int mark, Answer[] answerList, Answer rightAnswer)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(header);
            ArgumentException.ThrowIfNullOrWhiteSpace(body);
            ArgumentNullException.ThrowIfNull(answerList);
            ArgumentNullException.ThrowIfNull(rightAnswer);

            if (mark <= 0)
                throw new ArgumentOutOfRangeException(nameof(mark), "Mark must be greater than zero.");

            if (answerList.Length == 0)
                throw new ArgumentException("A question must have at least one answer.", nameof(answerList));

            if (!answerList.Contains(rightAnswer))
                throw new ArgumentException("The correct answer must exist in the answer list.", nameof(rightAnswer));

            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = answerList;
            RightAnswer = rightAnswer;

        }


    }

}
