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
            Time = time;
            NumOfQuestions = numOfQuestions;
            Questions = questions;
        }
        public abstract void ShowExam();
    }
}
