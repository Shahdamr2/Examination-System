
using ExaminationSystem.Domain.Enums;
using ExaminationSystem.Domain.Entities;
using ExaminationSystem.Domain.Questions.Base;
using ExaminationSystem.Domain.Questions.Types;
using ExaminationSystem.Domain.Exams.Base;

namespace Examination_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the type of exam (1 for Practical, 2 for Final):");

            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice) ||
                   (choice != 1 && choice != 2))
            {
                Console.WriteLine("Invalid choice. Enter 1 for Practical or 2 for Final:");
            }

            ExamType examType = (ExamType)choice;

            Console.WriteLine("Please enter the time for the exam (30 to 180 minutes):");

            int duration;

            while (!int.TryParse(Console.ReadLine(), out duration) ||
                   duration < 30 || duration > 180)
            {
                Console.WriteLine("Invalid duration. Enter a value between 30 and 180 minutes:");
            }

            TimeSpan examTime = TimeSpan.FromMinutes(duration);

            Console.WriteLine("Please enter the number of questions:");

            int numOfQuestions;

            while (!int.TryParse(Console.ReadLine(), out numOfQuestions) ||
                   numOfQuestions <= 0)
            {
                Console.WriteLine("Invalid number. Enter a positive number of questions:");
            }

            Question[] questions = new Question[numOfQuestions];

            for (int i = 0; i < numOfQuestions; i++)
            {
                Console.Clear();

                Console.WriteLine($"Enter details for question {i + 1}:");

                int questionType = 1;

                if (examType == ExamType.Final)
                {
                    Console.WriteLine("Choose question type: 1 for MCQ, 2 for True/False:");

                    while (!int.TryParse(Console.ReadLine(), out questionType) ||
                           (questionType != 1 && questionType != 2))
                    {
                        Console.WriteLine("Invalid choice. Enter 1 for MCQ or 2 for True/False:");
                    }
                }

                Console.WriteLine("Please enter the question header:");

                string header = Console.ReadLine() ?? "";

                while (string.IsNullOrWhiteSpace(header))
                {
                    Console.WriteLine("Header cannot be empty. Please enter the question header:");
                    header = Console.ReadLine() ?? "";
                }

                Console.WriteLine("Please enter the question body:");

                string body = Console.ReadLine() ?? "";

                while (string.IsNullOrWhiteSpace(body))
                {
                    Console.WriteLine("Question body cannot be empty. Please enter the question body:");
                    body = Console.ReadLine() ?? "";
                }

                Console.WriteLine("Please enter the question mark:");

                int mark;

                while (!int.TryParse(Console.ReadLine(), out mark) || mark <= 0)
                {
                    Console.WriteLine("Invalid mark. Enter a positive number:");
                }

                int numOfAnswers = 2;

                if (questionType == 1)
                {
                    Console.WriteLine("Please enter the number of choices:");

                    while (!int.TryParse(Console.ReadLine(), out numOfAnswers) ||
                           numOfAnswers < 2)
                    {
                        Console.WriteLine("Invalid number. Enter at least 2 choices:");
                    }
                }

                Answer[] answers = new Answer[numOfAnswers];

                for (int j = 0; j < answers.Length; j++)
                {
                    if (questionType == 2)
                    {
                        answers[j] = new Answer(j + 1, j == 0 ? "True" : "False");
                        continue;
                    }

                    Console.WriteLine($"Please enter choice number {j + 1}:");

                    string answerText = Console.ReadLine() ?? "";

                    while (string.IsNullOrWhiteSpace(answerText))
                    {
                        Console.WriteLine("Choice cannot be empty. Please enter it again:");
                        answerText = Console.ReadLine() ?? "";
                    }

                    answers[j] = new Answer(j + 1, answerText);
                }

                if (questionType == 2)
                {
                    Console.WriteLine("Please enter the ID of the correct answer (1 for True, 2 for False):");
                }
                else
                {
                    Console.WriteLine($"Please enter the ID of the correct answer (1 to {answers.Length}):");
                }

                int rightAnswerId;

                while (!int.TryParse(Console.ReadLine(), out rightAnswerId) ||
                       rightAnswerId < 1 || rightAnswerId > answers.Length)
                {
                    Console.WriteLine($"Invalid ID. Enter a number from 1 to {answers.Length}:");
                }

                Answer rightAnswer = answers[rightAnswerId - 1];

                if (questionType == 1)
                {
                    questions[i] = new MCQQuestion(header, body, mark, answers, rightAnswer);
                }
                else
                {
                    questions[i] = new TrueFalseQuestion(header, body, mark, answers, rightAnswer);
                }
            }

            Console.Clear();

            Console.WriteLine("========================================");
            Console.WriteLine("           EXAMINATION SYSTEM");
            Console.WriteLine("========================================");
            Console.WriteLine();

            Console.WriteLine("Do You Want To Start Exam (Y | N):");

            string startChoice = Console.ReadLine()?.Trim() ?? "";

            while (!startChoice.Equals("Y", StringComparison.OrdinalIgnoreCase) &&
                   !startChoice.Equals("N", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Invalid choice. Enter Y to start or N to cancel:");
                startChoice = Console.ReadLine()?.Trim() ?? "";
            }

            if (startChoice.Equals("N", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Exam cancelled.");
                return;
            }

            Console.Clear();

            Subject subject = new Subject(1, "C# Programming");

            subject.CreateExam(examType, examTime, numOfQuestions, questions);

            subject.Exam?.ShowExam();
        }
    }
}
