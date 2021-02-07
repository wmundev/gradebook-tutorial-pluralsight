using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        private List<double> grades ;
        private string name;
        public Book(string name)
        {
            this.grades = new List<double>();
            this.name = name;
        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public Stats GetStats()
        {
            Stats stats = new Stats();
            double result = 0.0;
            double highGrade = double.MinValue;
            double lowGrade = double.MaxValue;
            // for (int i = 0; i < numbers.Count; i++)
            // {
            // result += numbers[i];
            // }

            foreach (double number in grades)
            {
                highGrade = Math.Max(number, highGrade);
                lowGrade = Math.Min(number, lowGrade);
                result += number;
            }
            stats.Average = result / grades.Count;
            stats.High = highGrade;
            stats.Low = lowGrade;
            return stats;
        }

        public void ShowStats()
        {
            Stats CalculatedStats = GetStats();
            
            Console.WriteLine($"High Grade {CalculatedStats.High}");
            Console.WriteLine($"Low Grade {CalculatedStats.Low}");
            Console.WriteLine($"Average {CalculatedStats.Average:N1}");
        }
    }
}