using LibrarySystem.Models.BookModel;
using LibrarySystem.Search;
using LibrarySystem.UserCommunication;
using LibrarySystem.Validation;
using LibrarySystemTest.Fixture;
using Moq;

namespace LibrarySystemTest.SearchTest;

[Collection("BookStorage Collection")]
public class BookSearcherByIsbnTest(SharedBookStorageFixture fixture)
{
    [Fact]
    public void Search_ShallReturnMatchingeBooks_IfBookWithPassedIsbnIsAvailable()
    {
        //Arrange
        var bookValidator = new BookValidator();
        var userCommunicatorMock = new Mock<IUserCommunicator>();
        userCommunicatorMock.Setup(console => console
                .ReadValidFromUser("ISBN", bookValidator.IsValidIsbn))
            .Returns("1234098765432");
        var expectedResult = new List<Book>
        {
            new("Love", "Cupid", "1234098765432")
        }.AsEnumerable();
        
        //Act
        var result = new BookSearcherByIsbn(userCommunicatorMock.Object, bookValidator)
            .Search(fixture.BookStorageMock.Object);
        
        //Assert
        Assert.Equal(expectedResult, result);
    }
}