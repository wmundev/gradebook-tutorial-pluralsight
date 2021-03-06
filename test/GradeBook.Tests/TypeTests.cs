using System;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Xunit;

namespace GradeBook.Tests
{

    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTests
    
    {
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log;
            
            //normal delegates
            log = new WriteLogDelegate(ReturnMessage);
            
            //multi cast delegates
            log += ReturnDiffMessage;

            var result = log("Hello!");
            Assert.Equal("huh", result);
        }

        string ReturnMessage(string message)
        {
            return message;
        }
        
        string ReturnDiffMessage(string message)
        {
            return "huh";
        }
        
        
        [Fact]
        public void GetBookReturnsDifferentObjects()
        {

            InMemoryBook book1 = GetBook("Book 1");
            InMemoryBook book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
        }
        
        [Fact]
        public void TwoVarsCanRefSameObject()
        {

            InMemoryBook book1 = GetBook("Book 1");
            InMemoryBook book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }
        
        [Fact]
        public void CanSetNameFromReference()
        {

            InMemoryBook book1 = GetBook("Book 1");
            SetName(book1, "New Name");
            
            Assert.Equal(book1.Name, "New Name");
        }

        public void SetName(InMemoryBook inMemoryBook, string NewName)
        {
            inMemoryBook.Name = NewName;
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }

          
        [Fact]
        public void CanPassByRef()
        {

            InMemoryBook book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");
            
            Assert.Equal(book1.Name, "New Name");
        }

        private void GetBookSetName(ref InMemoryBook inMemoryBook, string name)
        {
            inMemoryBook = new InMemoryBook(name);
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
