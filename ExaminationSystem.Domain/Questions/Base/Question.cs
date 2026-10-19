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
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = answerList;
            RightAnswer = rightAnswer;
        }

    }
}
