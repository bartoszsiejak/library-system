using LibrarySystem.Validation;

namespace LibrarySystemTest.ValidationTest;

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
   
   [Theory]
   [InlineData("123456789")]
   [InlineData("12345678910")]
   [InlineData("33333333-x")]
   public void IsValidIsbn_ShallReturnFalse_IfIsbnIsInvalid(string isbn)
   {
      //Arrange
      var cut = new BookValidator();
      
      //Act
      var result = cut.IsValidIsbn(isbn);
      
      //Assert
      Assert.False(result);
   }
   
   [Theory]
   [InlineData("978-1-56619-909-4")]
   [InlineData("1-56619-909-3")]
   [InlineData("1248752418865")]
   [InlineData("1257561035")]
   public void IsValidIsbn_ShallReturnTrue_IfIsbnIsValid(string isbn)
   {
      //Arrange
      var cut = new BookValidator();
      
      //Act
      var result = cut.IsValidIsbn(isbn);
      
      //Assert
      Assert.True(result);
   }
}