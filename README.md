# Examination System

A console-based Examination System developed using C# and Object-Oriented Programming (OOP).

This project is designed to demonstrate fundamental OOP principles through a practical examination system that supports different question types and exam formats.

## Project Objectives

- Apply Object-Oriented Programming principles in a real-world scenario.
- Practice inheritance, abstraction, polymorphism, and encapsulation.
- Organize code using a clean, maintainable project structure.
- Implement interfaces and explore object comparison and cloning.
- Develop the system incrementally, testing each component before integration.

## Features

### Question Management
- Base `Question` class.
- True/False questions.
- Multiple-choice questions (MCQ).
- Answer management and correct-answer identification.
- Question marks and validation.

### Exam Management
- Base `Exam` class.
- Final Exam supporting True/False and MCQ questions.
- Practical Exam supporting MCQ questions.
- Exam duration and question count.
- Different exam-display behaviors.
- Grade calculation and result display.
- Displaying correct answers after completing a Practical Exam.

### Subject Management
- Subject identification and naming.
- Association between subjects and exams.
- Functionality to create an exam for a subject.

## Technical Concepts

- Classes and Objects
- Encapsulation
- Inheritance
- Abstraction
- Polymorphism
- Method Overriding
- Interfaces: `ICloneable` and `IComparable`
- `ToString()` overriding
- Constructor Chaining
- Arrays and Object Relationships
- Input Validation and Exception Handling, where appropriate

## Architecture

The project will follow a structured, object-oriented design inspired by Onion Architecture principles, adapted to the scope of a C# console application.

The architecture and project structure will be refined during development to keep responsibilities clear and avoid unnecessary complexity.

## Technologies

- C#
- .NET
- Visual Studio
- Git and GitHub

## Development Approach

The project is being developed incrementally:

1. Project planning and documentation.
2. Solution and project structure setup.
3. Implementation of the core classes.
4. Implementation of inheritance and polymorphic exam behavior.
5. Integration of subjects, questions, and answers.
6. Implementation and testing of required interfaces.
7. Exam execution and grade calculation.
8. Final testing and code review.

Each stage will be reviewed, committed, and pushed to GitHub to maintain a clear development history.

## Project Status

**Status:** In Progress

This project is being developed as part of a C# and OOP examination assignment.

## Author

Developed as an educational project to practice C# programming and object-oriented software design.
