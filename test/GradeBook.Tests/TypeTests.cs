using System;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    
    {
        [Fact]
        public void GetBookReturnsDifferentObjects()
        {

            Book book1 = GetBook("Book 1");
            Book book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
        }
        
        [Fact]
        public void TwoVarsCanRefSameObject()
        {

            Book book1 = GetBook("Book 1");
            Book book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }
        
        [Fact]
        public void CanSetNameFromReference()
        {

            Book book1 = GetBook("Book 1");
            SetName(book1, "New Name");
            
            Assert.Equal(book1.Name, "New Name");
        }

        public void SetName(Book book, string NewName)
        {
            book.Name = NewName;
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }

          
        [Fact]
        public void CanPassByRef()
        {

            Book book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");
            
            Assert.Equal(book1.Name, "Book 1");
        }

        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
        }
        
        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Scott";
            string newName = MakeUppercase(name);
            
            Assert.Equal(newName, "SCOTT");
        }

        private string MakeUppercase(string name)
        {
            return name.ToUpper();
        }
    }
}
