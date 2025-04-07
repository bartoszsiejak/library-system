using LibrarySystem.UserCommunication;
using Moq;

namespace LibrarySystemTest.UserCommunicationTest;

public class ConsoleUserCommunicatorTest
{
    private readonly Mock<IConsole> _mock;
    private readonly ConsoleUserCommunicator _cut;

    public ConsoleUserCommunicatorTest()
    {
        //Arrange
        _mock = new Mock<IConsole>();
        _cut = new ConsoleUserCommunicator(_mock.Object);
    }

    [Fact]
    public void PrintTest_ShallPrintMessage()
    {
        //Act
        _cut.Print("Test");

        //Assert
        _mock.Verify(console => console.WriteLine("Test"));
    }

    [Fact]
    public void ClearWindowTest_ShallClearWindow()
    {
        //Act
        _cut.ClearWindow();

        //Assert
        _mock.Verify(console => console.Clear());
    }

    [Fact]
    public void WaitForKey_ShallWaitForKey()
    {
        //Act
        _cut.WaitForKey();

        //Assert
        _mock.Verify(console => console.WriteLine(It.IsAny<string>()));
        _mock.Verify(console => console.ReadKey(true));
    }

    [Fact]
    public void ReadOptionFromUser_ShallReturnChar()
    {
        //Arrange
        _mock.Setup(console => console.ReadKey(true))
            .Returns(new ConsoleKeyInfo('d', ConsoleKey.D, false, false, false));

        //Act
        var result = _cut.ReadOptionFromUser();

        //Assert
        Assert.Equal('d', result);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("0", 0)]
    [InlineData("47", 47)]
    public void ReadCustomerIdFromUser_ShallReturnUnsignedInt_IfFirstAttemptIsParsable(string input,
        uint expectedResult)
    {
        //Arrange
        _mock.Setup(console => console.ReadLine()).Returns(input);

        //Act
        var result = _cut.ReadCustomerIdFromUser();

        //Assert
        Assert.Equal(expectedResult, result);
    }

    public static TheoryData<string[], uint> GetCustomerIdInput = new()
    {
        { ["xd", "333"], 333u },
        { ["xd", "dd", "4"], 4u },
        { ["xd", "", "-1", "5"], 5u }
    };

    [Theory]
    [MemberData(nameof(GetCustomerIdInput))]
    public void ReadCustomerIdFromUser_ShallReturnUnsignedInt_IfConsecutiveAttemptIsParsable(
        string[] input,
        uint expectedResult)
    {
        // Arrange
        var sequence = _mock.SetupSequence(console => console.ReadLine());
        foreach (var line in input)
        {
            sequence.Returns(line);
        }

        //Act
        var result = _cut.ReadCustomerIdFromUser();

        //Assert
        _mock.Verify(
            console => console.WriteLine("Customer ID must be a positive integer!"),
            Times.Exactly(input.Length - 1));
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void ReadValidFromUser_ShallReturnNonEmptyString_IfPassCorrectValidator()
    {
        //Arrange
        _mock.SetupSequence(console => console.ReadLine())
            .Returns("")
            .Returns("Non empty string");
        var validator = (string text) => text.Length > 0;

        //Act
        var result = _cut.ReadValidFromUser("name", validator);

        //Assert
        Assert.Equal("Non empty string", result);
    }

    public static TheoryData<int, string[], int> ReadValidBookIndexFromUserParameters = new()
    {
        { 1, ["5", "10", "1"], 1 },
        { 5, ["6", "10", "4"], 4 },
        { 10, ["9"], 9 }
    };

    [Theory]
    [MemberData(nameof(ReadValidBookIndexFromUserParameters))]
    public void ReadValidBookIndexFromUser_ShallReturnValidBookIndex(
        int numberOfItems,
        string[] input,
        int expectedResult)
    {
        //Arrange
        var setupSequence = _mock.SetupSequence(console => console.ReadLine());
        foreach (var line in input)
        {
            setupSequence.Returns(line);
        }

        //Act
        var result = _cut.ReadValidBookIndexFromUser(numberOfItems);

        //Assert
        Assert.Equal(expectedResult, result);
    }
}