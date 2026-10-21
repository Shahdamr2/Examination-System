
using System;
using System.Diagnostics;
using System.Linq;
using ExaminationSystem.Domain.Exams.Base;
using ExaminationSystem.Domain.Entities;
using ExaminationSystem.Domain.Questions.Base;
using ExaminationSystem.Domain.Questions.Types;

namespace ExaminationSystem.Domain.Exams.Types;

public class FinalExam : Exam
{
    public FinalExam(TimeSpan time, int numOfQuestions, Question[] questions)
        : base(time, numOfQuestions, questions)
    {
        if (questions.Any(question =>
            question is not MCQQuestion && question is not TrueFalseQuestion))
        {
            throw new ArgumentException(
                "Final exams support MCQ and True/False questions only.",
                nameof(questions));
        }
    }

    public override void ShowExam()
    {
        string[] studentAnswers = new string[Questions.Length];
        int studentMark = 0;
        int totalMark = 0;

        Console.WriteLine("Final Exam");

        Stopwatch stopwatch = Stopwatch.StartNew();

        for (int i = 0; i < Questions.Length; i++)
        {
            Question question = Questions[i];

            Console.WriteLine($"Question {i + 1}: {question.Body}");

            if (question is MCQQuestion)
            {
                Console.WriteLine($"MCQ Question:    Mark {question.Mark}");

                foreach (Answer answer in question.AnswerList!)
                {
                    Console.WriteLine($"{answer.AnswerId}- {answer.AnswerText}");
                }
            }
            else if (question is TrueFalseQuestion)
            {
                Console.WriteLine(
                    $"True | False Question:  Mark {question.Mark}");

                Console.WriteLine($"True/False Question: {question.Body}");

                foreach (Answer answer in question.AnswerList!)
                {
                    Console.WriteLine($"{answer.AnswerId}- {answer.AnswerText}");
                }
            }

            Console.Write("Enter your answer ID: ");

            int answerId;

            while (!int.TryParse(Console.ReadLine(), out answerId) ||
                   !question.AnswerList!.Any(answer => answer.AnswerId == answerId))
            {
                Console.Write("Invalid Answer ID. Try again: ");
            }

            Answer selectedAnswer = question.AnswerList!
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

        Console.WriteLine("Final Exam Results:");

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
