using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void NewBooksAreIndependent()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            book2.Name = "Book 2";

            Assert.Same(book1, book2);

            Assert.Equal("Book 2", book1.Name);
        }


        [Fact]
        public void BookPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");
            Assert.Equal("Book 1", book1.Name);

        }

        [Fact]
        public void BookPassByReference()
        {
            var book1 = GetBook("Book 1");
            GetBookSetNameRef(ref book1, "New Name");
            Assert.Equal("New Name", book1.Name);

        }

        [Fact]
        public void GetSetValueType()
        {
            var x = GetInt();
            SetInt(x);
            Assert.Equal(3, x);
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Davey";
            MakeUppercase(name);
            Assert.Equal("Davey", name);
        }

        private void MakeUppercase(string input)
        {
            input = input.ToUpper();
        }

        private Book GetBook(string name)
        {
            return new Book(name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
            book.Name = name;
        }


        private void GetBookSetNameRef(ref Book book, string name)
        {
            book = new Book(name);
            book.Name = name;
        }

        private int GetInt()
        {
            return 3;
        }

        private void SetInt(int x)
        {
            x = 17;
        }
    }
}
