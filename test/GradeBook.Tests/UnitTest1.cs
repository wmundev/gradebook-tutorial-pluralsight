using System;
using Xunit;

namespace GradeBook.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestBookName()
        {
            string BookName = "new book";
            Book book = new Book(BookName);
            
            Assert.Equal(book.Name, BookName);
        }

        [Fact]
        public void TestShowStats()
        {
            string BookName = "new book";
            Book book = new Book(BookName);
            book.AddGrade(20.0);
            book.AddGrade(40.0);
            
            Stats result = book.GetStats();

            Assert.Equal(result.Low, 20.0);
            Assert.Equal(result.High, 40.0);
            Assert.Equal(result.Average, 30.0);
        }
    }
}
