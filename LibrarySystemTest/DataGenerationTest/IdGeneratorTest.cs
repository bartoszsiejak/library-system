using LibrarySystem.DataGeneration;

namespace LibrarySystemTest.DataGenerationTest;

public class IdGeneratorTest
{
    [Fact]
    public void GetId_ShallThrowException_WhenOverflowOccur()
    {
        //Arrange
        var cut = new IdGenerator(uint.MaxValue);
        
        //Act & Assert
        Assert.Throws<OverflowException>(() => cut.GetId());
    }
    
    [Fact]
    public void GetId_ShallReturnValidId()
    {
        //Arrange
        var cut = new IdGenerator(0);
        
        //Act
        var firstResult = cut.GetId();
        var secondResult = cut.GetId();
        // Assert
        Assert.Equal(0u, firstResult);
        Assert.Equal(1u, secondResult);
    }
}