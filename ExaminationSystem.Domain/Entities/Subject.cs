using ExaminationSystem.Domain.Exams.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem.Domain.Entities
{
    internal class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam Exam { get; set; }
        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }
    }
}
