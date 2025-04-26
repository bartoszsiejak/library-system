using LibrarySystem.Models.BookModel;
using LibrarySystem.Models.CustomerModel;

namespace LibrarySystemTest.ModelsTest.BookModelTest;

public class BookTest
{
    [Fact]
    public void Lend_ShallSetBorrower()
    {
        //Arrange
        var book = new Book("Lord Of The Rings", "Tolkien", "1234567890");
        var customer = new Customer(1u, "Bartosz", "Nowak");

        //Act
        book.Lend(customer);

        //Assert
        Assert.NotNull(book.Borrower);
        Assert.Equal(customer, book.Borrower);
        Assert.Contains(book, customer.BorrowedBooks);
    }

    [Fact]
    public void Lend_ShallThrowException_IfBorrowerIsNotNull()
    {
        //Arrange
        var book = new Book("Lord Of The Rings", "Tolkien", "1234567890");
        var customer = new Customer(1u, "Bartosz", "Nowak");
        book.Lend(customer);
        
        //Act & Assert
        var exception = Assert.Throws<InvalidOperationException>(() => book.Lend(customer));
        Assert.Equal("Borrower is not null.", exception.Message);
    }

    [Fact]
    public void Return_ShallReturnBook_IfIsCurrentlyBorrowed()
    {
        //Arrange
        var book = new Book("Lord Of The Rings", "Tolkien", "1234567890");
        var customer = new Customer(1u, "Bartosz", "Nowak");
        book.Lend(customer);
        
        //Act
        book.Return();
        
        //Assert
        Assert.Null(book.Borrower);
        Assert.DoesNotContain(book, customer.BorrowedBooks);
    }

    [Fact]
    public void Return_ShallThrowException_IfBorrowerIsNull()
    {
        //Arrange
        var book = new Book("Lord Of The Rings", "Tolkien", "1234567890");
        
        //Act & Assert
        Assert.Throws<NullReferenceException>(()=> book.Return());
    }
}