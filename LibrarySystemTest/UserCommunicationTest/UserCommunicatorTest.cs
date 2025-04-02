using System.Buffers;
using LibrarySystem.UserCommunication;
using Moq;

namespace LibrarySystemTest.UserCommunicationTest;

public class ConsoleUserCommunicatorTest
{
    private readonly Mock<IConsole> mock;
    private readonly ConsoleUserCommunicator cut;

    public ConsoleUserCommunicatorTest()
    {
        mock = new Mock<IConsole>();
        cut = new ConsoleUserCommunicator(mock.Object);
    }
    
    [Fact]
    public void GetValidTittle_ShallReturnTittle_IfNonEmptyString()
    {
        //Arrange
        const string Tittle = "It Is Valid Tittle!";
        mock.Setup(console => console.ReadLine())
            .Returns(Tittle);
        
        //Act
        var result = cut.GetValidTittle();
        
        //Assert
        Assert.Equal(Tittle, result);
    }
    
    [Fact]
    public void GetValidTittle_ShallPrintMessage_IfNonValidTittle()
    {
        //Arrange
        mock.SetupSequence(console => console.ReadLine())
            .Returns("")
            .Returns("It Is Valid Tittle!");
        
        //Act
        var result = cut.GetValidTittle();
        
        //Assert
        mock.Verify(console => console.WriteLine("Tittle must be at least one character!"), Times.Once);
        Assert.Equal("It Is Valid Tittle!", result);
    }

    [Fact]
    public void GetValidAuthor_ShallReturnAuthor_IfValidString()
    {
        //Arrange
        
        const string Author = "It Is Valid Author!";
        mock.Setup(console => console.ReadLine())
            .Returns(Author);
        
        //Act
        var result = cut.GetValidAuthor();
        
        //Assert
        Assert.Equal(Author, result);
    } 
    
    [Fact]
    public void GetValidAuthor_ShallReturnAuthor_IfFourthAttemptIsValid()
    {
        //Arrange
        mock.SetupSequence(console => console.ReadLine())
            .Returns("It-is-invalid.author")
            .Returns("cs Lewis")
            .Returns("CS")
            .Returns("C.S.S Lewis");
        
        //Act
        var result = cut.GetValidAuthor();
        
        //Assert
        mock.Verify(console => console.WriteLine("Invalid author!"), Times.Exactly(2));
        mock.Verify(console => console.WriteLine("Author must be at least 3 characters!"), Times.Once);
        Assert.Equal("C.S.S Lewis", result);
    }
}