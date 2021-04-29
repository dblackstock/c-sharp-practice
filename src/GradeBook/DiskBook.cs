using System;
using System.IO;
using System.Text.RegularExpressions;

namespace GradeBook
{
    public class DiskBook : Book
    {
        private string fileName;
        public DiskBook(string name) : base(name)
        {
            Name = name;
            fileName = $"./{Name}.txt";
        }


        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            var stringGrade = Convert.ToString(grade);
            WriteGradeToFile(stringGrade);
        }

        private void WriteGradeToFile(string grade)
        {
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine($"{grade}");
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override void AddGrade(string grade)
        {
            if (IsGradeValid(grade))
            {
                WriteGradeToFile(grade);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Valid grades are A,B,C,D,F.");
            }
        }

        public override string[] ReadExistingGrades()
        {
            StreamWriter writer = new StreamWriter(fileName, true);
            string[] grades = new string[0];
            grades = File.ReadAllLines(fileName); 
            return grades;
        }

    }
}