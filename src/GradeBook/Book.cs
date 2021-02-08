using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        private List<double> grades;
        private string name;
        private readonly string category;
        private const string WOW = "wow";
        public event GradeAddedDelegate GradeAdded;

        public Book(string name)
        {
            this.grades = new List<double>();
            this.name = name;
            category = "Science";
        }

        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException("Invalid grade");
            }
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

            switch (stats.Average)
            {
                case var d when d >= 90.0:
                    stats.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    stats.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    stats.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    stats.Letter = 'D';
                    break;
                default:
                    stats.Letter = 'F';
                    break;
            }
            
            return stats;
        }

        public void ShowStats()
        {
            Stats CalculatedStats = GetStats();

            Console.WriteLine($"High Grade {CalculatedStats.High}");
            Console.WriteLine($"Low Grade {CalculatedStats.Low}");
            Console.WriteLine($"Average {CalculatedStats.Average:N1}");
        }

        public void AddLetterGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }
    }
}