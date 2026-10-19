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

    }
}
