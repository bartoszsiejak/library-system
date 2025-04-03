using LibrarySystem.BookModel;

namespace LibrarySystemTest.BookModelTest;

public class BookValidatorTest
{
   [Theory]
   [InlineData("C.S Levis")]
   [InlineData("Andersen")]
   [InlineData("John Big-Kennedy")]
   public void IsValidAuthor_ShallReturnTrue_IfAuthorIsValid(string name)
   {
      //Arrange
      var cut = new BookValidator();
      
      //Act
      var result = cut.IsValidAuthor(name);
      
      //Assert
      Assert.True(result);
   }
   
   [Theory]
   [InlineData("C.s Levis")]
   [InlineData("andersen")]
   [InlineData("John Big-kennedy")]
   public void IsValidAuthor_ShallReturnFalse_IfAuthorIsInvalid(string name)
   {
      //Arrange
      var cut = new BookValidator();
      
      //Act
      var result = cut.IsValidAuthor(name);
      
      //Assert
      Assert.False(result);
   }
}