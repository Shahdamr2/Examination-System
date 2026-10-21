
using System;
using System.Diagnostics;
using System.Linq;
using ExaminationSystem.Domain.Exams.Base;
using ExaminationSystem.Domain.Questions.Base;
using ExaminationSystem.Domain.Questions.Types;

namespace ExaminationSystem.Domain.Exams.Types;

public class PracticalExam : Exam
{
    public PracticalExam(TimeSpan time, int numOfQuestions, Question[] questions)
        : base(time, numOfQuestions, ValidateQuestions(questions))
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
        string[] studentAnswers = new string[Questions.Length];
        int studentMark = 0;
        int totalMark = 0;

        Stopwatch stopwatch = Stopwatch.StartNew();

        for (int i = 0; i < Questions.Length; i++)
        {
            Question question = Questions[i];

            Console.WriteLine($"\nQuestion {i + 1}: {question.Body}");

            foreach (var answer in question.AnswerList!)
            {
                Console.WriteLine($"{answer.AnswerId}. {answer.AnswerText}");
            }

            Console.Write("Enter Answer ID: ");

            int answerId;

            while (!int.TryParse(Console.ReadLine(), out answerId) ||
                   !question.AnswerList!.Any(answer => answer.AnswerId == answerId))
            {
                Console.Write("Invalid Answer ID. Try again: ");
            }

            var selectedAnswer = question.AnswerList!
                .First(answer => answer.AnswerId == answerId);

            studentAnswers[i] = selectedAnswer.AnswerText;

            if (answerId == question.RightAnswer!.AnswerId)
            {
                studentMark += question.Mark;
            }

            totalMark += question.Mark;
        }

        stopwatch.Stop();

        Console.Clear();

        Console.WriteLine("Practical Exam Results:");

        for (int i = 0; i < Questions.Length; i++)
        {
            Question question = Questions[i];

            Console.WriteLine($"Question {i + 1}: {question.Body}");
            Console.WriteLine($"Your Answer => {studentAnswers[i]}");
            Console.WriteLine($"Correct Answer => {question.RightAnswer!.AnswerText}");
            Console.WriteLine();
        }

        Console.WriteLine($"Your Grade is {studentMark} from {totalMark}");
        Console.WriteLine($"Time = {stopwatch.Elapsed}");
        Console.WriteLine("Thank you");
    }
}
