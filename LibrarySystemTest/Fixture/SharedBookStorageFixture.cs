using LibrarySystem.DataStructures;
using LibrarySystem.Models.BookModel;
using Moq;

namespace LibrarySystemTest.Fixture;

public class SharedBookStorageFixture
{
    public Mock<IBookStorage> BookStorageMock { get; private set; }
    
    public SharedBookStorageFixture()
    {
        var books = new List<Book>
        {
            new("LOTR", "Tolkien", "1234567890"),
            new("Test", "Arthurito", "1294367390"),
            new("Hobbit", "Tolkien", "3141414132"),
            new("Love", "Cupid", "1234098765432"),
        };
        
        BookStorageMock = new Mock<IBookStorage>();
        BookStorageMock.Setup(storage => storage.Books).Returns(books);
    }
}