using System;
using System.Linq;
using ExaminationSystem.Domain.Exams.Base;
using ExaminationSystem.Domain.Questions.Base;
using ExaminationSystem.Domain.Questions.Types;

namespace ExaminationSystem.Domain.Exams.Types;

public class PracticalExam : Exam
{

    public PracticalExam(TimeSpan time, int numOfQuestions, Question[] questions): base(time, numOfQuestions, ValidateQuestions(questions))
    {
    }
    private static Question[] ValidateQuestions(Question[] questions)
    {
        ArgumentNullException.ThrowIfNull(questions);

        if (questions.Any(question => question is not MCQQuestion))
            throw new ArgumentException("Practical exams support MCQ questions only.", nameof(questions));

        return questions;
    }
    public override void ShowExam()
    {
    }
}