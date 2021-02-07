namespace GradeBook
{
    public class Stats
    {
        private double average;

        public double Average
        {
            get
            {
                return average;
            }
            set
            {
                average = value;
            }
        }

        public double Low { get; set; }
        public double High { get; set; }
        public char Letter { get; set; }
    }
}