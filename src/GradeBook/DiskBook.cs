using System;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
            Name = name;
            // some code to create or link to a file
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            var stringGrade = Convert.ToString(grade);
            WriteGradeToFile(stringGrade);
        }

        private void WriteGradeToFile(string grade)
        {
            string fileName = $"./{Name}.txt";

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
            WriteGradeToFile(grade);
        }

        public override Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }
    }
}