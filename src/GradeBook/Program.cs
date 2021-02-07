using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("new book");
            // book.AddGrade(12.7);
            // book.AddGrade(10.3);
            // book.AddGrade(6.11);
            // book.AddGrade(4.1);
            // book.AddGrade(56.1);

            while (true)
            {
                string userInput = Console.ReadLine();
                try
                {
                    if (userInput == "q")
                    {
                        break;
                    }
                    double newInput = Convert.ToDouble(userInput);
                    book.AddGrade(newInput);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception {e}");
                }
            }
            
            book.ShowStats();
        }
    }
}