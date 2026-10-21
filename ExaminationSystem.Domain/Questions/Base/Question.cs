
using ExaminationSystem.Domain.Entities;
using ExaminationSystem.Domain.Questions.Types;
using System;
using System.Linq;

namespace ExaminationSystem.Domain.Questions.Base
{
    public abstract class Question : ICloneable, IComparable<Question>
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public Answer[]? AnswerList { get; set; }
        public Answer? RightAnswer { get; set; }

        protected Question(
            string header,
            string body,
            int mark,
            Answer[] answerList,
            Answer rightAnswer)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(header);
            ArgumentException.ThrowIfNullOrWhiteSpace(body);
            ArgumentNullException.ThrowIfNull(answerList);
            ArgumentNullException.ThrowIfNull(rightAnswer);

            if (mark <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(mark), "Mark must be greater than zero.");

            if (answerList.Length == 0)
                throw new ArgumentException(
                    "A question must have at least one answer.",
                    nameof(answerList));

            if (answerList.Any(answer => answer is null))
                throw new ArgumentException(
                    "Answer list cannot contain null values.",
                    nameof(answerList));

            if (!answerList.Contains(rightAnswer))
                throw new ArgumentException(
                    "The correct answer must exist in the answer list.",
                    nameof(rightAnswer));

            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = answerList;
            RightAnswer = rightAnswer;
        }

        public object Clone()
        {
            Answer[] clonedAnswers = AnswerList!
                .Select(answer =>
                    new Answer(answer.AnswerId, answer.AnswerText))
                .ToArray();

            Answer clonedRightAnswer = clonedAnswers
                .First(answer =>
                    answer.AnswerId == RightAnswer!.AnswerId);

            if (this is MCQQuestion)
            {
                return new MCQQuestion(
                    Header, Body, Mark,
                    clonedAnswers, clonedRightAnswer);
            }

            if (this is TrueFalseQuestion)
            {
                return new TrueFalseQuestion(
                    Header, Body, Mark,
                    clonedAnswers, clonedRightAnswer);
            }

            throw new InvalidOperationException(
                "Unknown question type.");
        }

        public int CompareTo(Question? other)
        {
            if (other is null)
                return 1;

            return Mark.CompareTo(other.Mark);
        }

        public override string ToString()
        {
            return $"Header: {Header}, Body: {Body}, Mark: {Mark}";
        }
    }
}
