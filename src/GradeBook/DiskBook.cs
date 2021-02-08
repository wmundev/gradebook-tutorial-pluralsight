using System;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book
    {
        public override event GradeAddedDelegate GradeAdded;

        public DiskBook(string name) : base(name)
        {
        }

        public override void AddGrade(double grade)
        {
            /**
             * "using" keyword here means asking the c# compiler to automatically
             * dispose after the end of the the curly braces
             *
             * this means the compiler guarantees that the writer will call
             * writer.Dispose() after we are done
             */
            using (StreamWriter writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine($"{grade}");
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Stats GetStats()
        {
            Stats stats = new Stats();

            using (StreamReader reader = File.OpenText($"{Name}.txt"))
            {
                String line;
                line = reader.ReadLine();
                while (line != null)
                {
                    stats.Add(Convert.ToDouble(line));
                    line = reader.ReadLine();
                }

            }


            return stats;

        }
    }
}