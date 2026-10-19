using ExaminationSystem.Domain.Exams.Base;
using ExaminationSystem.Domain.Questions.Base;

namespace ExaminationSystem.Domain.Exams.Types;

public class PracticalExam : Exam
{
    public PracticalExam(TimeSpan time, int numOfQuestions, Question[] questions): base(time, numOfQuestions, questions)
    {
    }
    public override void ShowExam()
    {
    }
}