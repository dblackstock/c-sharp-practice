using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class InMemoryBook : Book
    {

        private List<double> grades;
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }

        public InMemoryBook(string name, List<double> grades) : base(name)
        {
            this.grades = grades;
        }

        public List<double> Grades
        {
            get => grades;
            set => grades = value;
        }

        public override void AddGrade(double grade)
        {
            if (IsGradeValid(grade))
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException($"{nameof(grade)} must be between 0 and 100");
            }
        }

        public override void AddGrade(string grade)
        {
            if (IsGradeValid(grade))
            {
                var numberGrade = Statistics.LetterNumberGradeConvert(grade);
                AddGrade(numberGrade);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Valid grades are A,B,C,D,F.");
            }
        }

        public override event GradeAddedDelegate GradeAdded;
        public override string[] ReadExistingGrades() // In memory books have no capacity for reading in pre-existing grades
        { return new string[0]; }
    }
}