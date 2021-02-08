using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            // InMemoryBook inMemoryBook = new InMemoryBook("new book");
            IBook diskBook = new DiskBook("disk book");
            //add a delegate
            // inMemoryBook.GradeAdded += OnGradeAdded;

            // EnterGrades(inMemoryBook);
            EnterGrades(diskBook);
            
            // inMemoryBook.ShowStats();
            diskBook.ShowStats();
        }

        private static void EnterGrades(IBook inMemoryBook)
        {
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
                    inMemoryBook.AddGrade(newInput);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception {e}");
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs eventArgs)
        {
            Console.WriteLine("A grade was added");
        }
    }
}