using System;

namespace GradeBook
{
    public class Stats
    {
        private double average;

        public double Average
        {
            get { return Sum / Count; }
        }

        public double Low { get; set; }
        public double High { get; set; }
        public double Sum;
        public int Count;

        public void Add(double number)
        {
            Sum += number;
            Count += 1;
            Low = Math.Min(number, Low);
            High = Math.Max(number, High);
        }

        public Stats()
        {
            Sum = 0.0;
            High = double.MinValue;
            Low = double.MaxValue;
            Count = 0;
        }

        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90.0:
                        return 'A';
                    case var d when d >= 80.0:
                        return 'B';
                    case var d when d >= 70.0:
                        return 'C';
                    case var d when d >= 60.0:
                        return 'D';
                    default:
                        return 'F';
                }
            }
        }
    }
}