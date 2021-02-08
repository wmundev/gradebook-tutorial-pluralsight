using System;

namespace GradeBook
{
    public abstract class Book : NamedObject, IBook

    {
        public Book(string name) : base(name)
        {
        }

        public abstract void AddGrade(double grade);

        
        public abstract Stats GetStats();
        /**
         * virtual means a derived class might
         * choose to override the implementation details
         */
        public virtual event GradeAddedDelegate GradeAdded;
        
        public void ShowStats()
        {
            Stats CalculatedStats = GetStats();

            Console.WriteLine($"High Grade {CalculatedStats.High}");
            Console.WriteLine($"Low Grade {CalculatedStats.Low}");
            Console.WriteLine($"Average {CalculatedStats.Average:N1}");
        }
    }
}