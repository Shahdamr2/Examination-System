
using ExaminationSystem.Domain.Exams.Base;
using ExaminationSystem.Domain.Exams.Types;
using ExaminationSystem.Domain.Enums;
using ExaminationSystem.Domain.Questions.Base;

namespace ExaminationSystem.Domain.Entities
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam? Exam { get; private set; }

        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

        public void CreateExam(ExamType examType, TimeSpan time, int numOfQuestions, Question[] questions)
        {
            Exam = examType switch
            {
                ExamType.Practical => new PracticalExam(time, numOfQuestions, questions),
                ExamType.Final => new FinalExam(time, numOfQuestions, questions),
                _ => throw new ArgumentOutOfRangeException(nameof(examType))
            };
        }
    }
}
