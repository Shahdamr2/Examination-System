using ExaminationSystem.Domain.Questions.Base;


namespace ExaminationSystem.Domain.Exams.Base

{
    public abstract class Exam
    {
        public TimeSpan Time { get; set; }
        public int NumOfQuestions { get; set; }
        public Question[] Questions { get; set; }
        protected Exam(TimeSpan time, int numOfQuestions, Question[] questions)
        {
            ArgumentNullException.ThrowIfNull(questions);

            if (time < TimeSpan.FromMinutes(30) || time > TimeSpan.FromMinutes(180))
                throw new ArgumentOutOfRangeException(nameof(time), "Exam time must be between 30 and 180 minutes.");

            if (numOfQuestions <= 0 || numOfQuestions != questions.Length)
                throw new ArgumentException("Number of questions must match the questions array.");

            if (questions.Any(question => question is null))
                throw new ArgumentException("Questions cannot contain null values.", nameof(questions));

            Time = time;
            NumOfQuestions = numOfQuestions;
            Questions = questions;
        }
        public abstract void ShowExam();
    }
}
