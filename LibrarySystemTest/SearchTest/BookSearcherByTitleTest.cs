using LibrarySystem.Models.BookModel;
using LibrarySystem.Search;
using LibrarySystem.UserCommunication;
using LibrarySystem.Validation;
using LibrarySystemTest.Fixture;
using Moq;

namespace LibrarySystemTest.SearchTest;

[Collection("BookStorage Collection")]
public class BookSearcherByTitleTest(SharedBookStorageFixture fixture)
{
    [Fact]
    public void Search_ShallReturnSingleBook_IfPresentAuthorIsPassed()
    {
        //Arrange
        var bookValidator = new BookValidator();
        var title = "Love";
        var IUserCommunicatorMock = new Mock<IUserCommunicator>();
        var expected = new List<Book> { new("Love", "Cupid", "1234098765432") };
        IUserCommunicatorMock.Setup(
                console => console.ReadValidFromUser("title", bookValidator.IsValidTitle))
            .Returns("Love");


        //Act
        var result = new BookSearcherByTitle(IUserCommunicatorMock.Object, bookValidator)
            .Search(fixture.BookStorageMock.Object);

        //Assert
        Assert.Equal(expected, result);
    }
}