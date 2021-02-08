using System;
using System.Collections.Generic;

namespace GradeBook
{
    
    // : NamedObject means inheritance
    public class InMemoryBook : Book
    {
        private List<double> grades;
        private readonly string category;
        private const string WOW = "wow";
        public override event GradeAddedDelegate GradeAdded;

        // base is passing the parameter to the parent class
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            category = "Science";
        }
        // override the abstract method inherited from BookBase
        public override void AddGrade(double grade)
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

        public override Stats GetStats()
        {
            Stats stats = new Stats();
            // for (int i = 0; i < numbers.Count; i++)
            // {
            // result += numbers[i];
            // }

            foreach (double number in grades)
            {
                stats.Add(number);
            }

           
            
            return stats;
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