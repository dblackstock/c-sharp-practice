using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Grade book for Davey");
            book.AddGrade(32.5);
            book.AddGrade(83.1);
            book.AddGrade(29.3);

            var result = book.GetStatistics();
            result.ShowStatistics();
        }
    }


}
