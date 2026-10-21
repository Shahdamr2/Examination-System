
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
            Console.WriteLine("Choose Exam Type:");
            Console.WriteLine("1. Practical");
            Console.WriteLine("2. Final");
            Console.Write("Enter your choice: ");

            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
            {
                Console.Write("Invalid choice. Enter 1 for Practical or 2 for Final: ");
            }

            ExamType examType = (ExamType)choice;

            Console.Write("Enter exam duration in minutes: ");

            int duration;

            while (!int.TryParse(Console.ReadLine(), out duration) || duration < 30 || duration > 180)
            {
                Console.Write("Invalid duration. Enter a value between 30 and 180 minutes: ");
            }

            TimeSpan examTime = TimeSpan.FromMinutes(duration);

            Console.Write("Enter number of questions: ");

            int numOfQuestions;

            while (!int.TryParse(Console.ReadLine(), out numOfQuestions) || numOfQuestions <= 0)
            {
                Console.Write("Invalid number. Enter a positive number of questions: ");
            }

            Question[] questions = new Question[numOfQuestions];

            for (int i = 0; i < numOfQuestions; i++)
            {
                Console.WriteLine($"\nQuestion {i + 1}");

                int questionType = 1;

                if (examType == ExamType.Final)
                {
                    Console.WriteLine("Choose Question Type:");
                    Console.WriteLine("1. MCQ");
                    Console.WriteLine("2. True/False");
                    Console.Write("Enter your choice: ");

                    while (!int.TryParse(Console.ReadLine(), out questionType) ||
                           (questionType != 1 && questionType != 2))
                    {
                        Console.Write("Invalid choice. Enter 1 for MCQ or 2 for True/False: ");
                    }
                }

                Console.Write("Enter question header: ");
                string header = Console.ReadLine() ?? "";

                while (string.IsNullOrWhiteSpace(header))
                {
                    Console.Write("Header cannot be empty. Enter question header: ");
                    header = Console.ReadLine() ?? "";
                }

                Console.Write("Enter question body: ");
                string body = Console.ReadLine() ?? "";

                while (string.IsNullOrWhiteSpace(body))
                {
                    Console.Write("Question body cannot be empty. Enter question body: ");
                    body = Console.ReadLine() ?? "";
                }

                Console.Write("Enter question mark: ");
                int mark;

                while (!int.TryParse(Console.ReadLine(), out mark) || mark <= 0)
                {
                    Console.Write("Invalid mark. Enter a positive number: ");
                }

                int numOfAnswers = 2;

                if (questionType == 1)
                {
                    Console.Write("Enter number of choices: ");

                    while (!int.TryParse(Console.ReadLine(), out numOfAnswers) || numOfAnswers < 2)
                    {
                        Console.Write("Invalid number. Enter at least 2 choices: ");
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

                    Console.Write($"Please enter choice number {j + 1}: ");
                    string answerText = Console.ReadLine() ?? "";

                    while (string.IsNullOrWhiteSpace(answerText))
                    {
                        Console.Write("Choice cannot be empty. Please enter it again: ");
                        answerText = Console.ReadLine() ?? "";
                    }

                    answers[j] = new Answer(j + 1, answerText);
                }

                Console.Write($"Please enter the ID of the correct answer (1 to {answers.Length}): ");

                int rightAnswerId;

                while (!int.TryParse(Console.ReadLine(), out rightAnswerId) ||
                       rightAnswerId < 1 || rightAnswerId > answers.Length)
                {
                    Console.Write($"Invalid ID. Enter a number from 1 to {answers.Length}: ");
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

                Console.WriteLine("Question created successfully.");
            }


            Console.Clear();

            Console.WriteLine("========================================");
            Console.WriteLine("           EXAMINATION SYSTEM           ");
            Console.WriteLine("========================================");
            Console.WriteLine();

            Console.Write("Do You Want To Start Exam (Y | N): ");


            string startChoice = Console.ReadLine()?.Trim() ?? "";

            while (!startChoice.Equals("Y", StringComparison.OrdinalIgnoreCase) &&
                   !startChoice.Equals("N", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Invalid choice. Enter Y to start or N to cancel: ");
                startChoice = Console.ReadLine()?.Trim() ?? "";
            }

            if (startChoice.Equals("N", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Exam cancelled.");
                return;
            }

            Subject subject = new Subject(1, "C# Programming");

            subject.CreateExam(examType, examTime, numOfQuestions, questions);

            subject.Exam?.ShowExam();
        }
    }
}
