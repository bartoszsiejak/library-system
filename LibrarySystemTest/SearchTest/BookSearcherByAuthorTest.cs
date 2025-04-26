using LibrarySystem.Models.BookModel;
using LibrarySystem.Search;
using LibrarySystem.UserCommunication;
using LibrarySystem.Validation;
using LibrarySystemTest.Fixture;
using Moq;

namespace LibrarySystemTest.SearchTest;

[Collection("BookStorage Collection")]
public class BookSearcherByAuthorTest(SharedBookStorageFixture fixture)
{
    [Fact]
    public void Search_ShallReturnSingleAuthorBooks_IfAuthorIsPassed() 
    {
        //Arrange
        var bookValidator = new BookValidator();
        var author = "Tolkien";
        var IUserCommunicatorMock = new Mock<IUserCommunicator>();
        IUserCommunicatorMock
            .Setup(console => console
                .ReadValidFromUser("author", bookValidator.IsValidAuthor))
            .Returns(author);

        var cut = new BookSearcherByAuthor(IUserCommunicatorMock.Object, bookValidator);

        var expectedBooks = new List<Book>
        {
            new("LOTR", "Tolkien", "1234567890"),
            new("Hobbit", "Tolkien", "3141414132")
        }.AsEnumerable();

        //Act
        var result = cut.Search(fixture.BookStorageMock.Object);
        
        //Assert
        Assert.Equal(expectedBooks, result);
    }  
    
    [Fact]
    public void Search_ShallReturnEmptyCollection_IfNoMatchingAuthor() 
    {
        //Arrange
        var bookValidator = new BookValidator();
        var author = "Brzechwa";
        var IUserCommunicatorMock = new Mock<IUserCommunicator>();
        IUserCommunicatorMock
            .Setup(console => console
                .ReadValidFromUser("author", bookValidator.IsValidAuthor))
            .Returns(author);

        var cut = new BookSearcherByAuthor(IUserCommunicatorMock.Object, bookValidator);

        var expectedEmptyCollection = new List<Book>().AsEnumerable();

        //Act
        var result = cut.Search(fixture.BookStorageMock.Object);
        
        //Assert
        Assert.Equal(expectedEmptyCollection, result);
    }
}