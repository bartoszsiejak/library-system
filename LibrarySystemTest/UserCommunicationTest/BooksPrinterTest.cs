using LibrarySystem.Models.BookModel;
using LibrarySystem.UserCommunication;
using Moq;

namespace LibrarySystemTest.UserCommunicationTest;

public class BooksPrinterTest
{
    [Fact]
    public void BooksPrinter_ShallPrintThreeBooks()
    {
        //Arrange
        var mock = new Mock<IUserCommunicator>();
        var cut = new BooksPrinter(mock.Object);
        var books = new List<Book>()
        {
            new("The Chronicles of Narnia: the Lion, the Witch and the Wardrobe",
                "C.S. Lewis",
                "978-0064404990"),
            new("The Chronicles of Narnia: Prince Caspian",
                "C.S. Lewis",
                "978-0064471053"),
            new("The Voyage of the Dawn Treader",
                "C.S. Lewis", 
                "978-006440502"),
        };
        
        //Act
        cut.Print(books);
        
        //Arrange
        mock.Verify(communicator => communicator.Print(It.IsAny<string>()), Times.Exactly(books.Count));
    }
    
    [Fact]
    public void BooksPrinter_ShallPrintPropertyText_IfEmptyCollection()
    {
        //Arrange
        var mock = new Mock<IUserCommunicator>();
        var cut = new BooksPrinter(mock.Object);
        List<Book> books = [];
        
        //Act
        cut.Print(books);
        
        //Arrange
        mock.Verify(communicator => communicator.Print("Not found any books!"), Times.Once);
    }
}