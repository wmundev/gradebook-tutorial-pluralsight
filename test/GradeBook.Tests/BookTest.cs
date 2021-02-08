using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTest
    {
        [Fact]
        public void TestBookName()
        {
            string BookName = "new book";
            InMemoryBook inMemoryBook = new InMemoryBook(BookName);
            
            Assert.Equal(inMemoryBook.Name, BookName);
        }

        [Fact]
        public void TestShowStats()
        {
            string BookName = "new book";
            InMemoryBook inMemoryBook = new InMemoryBook(BookName);
            inMemoryBook.AddGrade(20.0);
            inMemoryBook.AddGrade(40.0);
            
            Stats result = inMemoryBook.GetStats();

            Assert.Equal(result.Low, 20.0);
            Assert.Equal(result.High, 40.0);
            Assert.Equal(result.Average, 30.0);
            Assert.Equal(result.Letter, 'F');
        }
    }
}
