using LibrarySystem.Data;
using LibrarySystem.UserCommunication;

namespace LibrarySystem;

public class LibrarySystemApp(IUserCommunicator userCommunicator)
{
    private readonly IUserCommunicator _userCommunicator = userCommunicator;
    public List<Book> Books { get; private set; } = [];

    public void Run()
    {
        _userCommunicator.Print(GetMainMenu());
        SelectOptionByUser();
    }

    private string GetMainMenu()
    {
        return """
               [S]earch book
               [A]dd book
               [M]anage customers
               [O]ptions
                               
               [E]xit
               """;
    }
    
    private void SelectOptionByUser()
    {
        while (true)
        {
            var chosenOption = _userCommunicator.GetKey();

            switch (char.ToUpper(chosenOption))
            {
                case 'S':
                    //SearchBook();
                    break;
                case 'A':
                    var book = CreateBookFromUser();
                    Books.Add(book);
                    break;
                case 'M':
                    //ManageCustomers();
                    break;
                case 'E':
                    Exit();
                    break;
            }
            
            return;
        }
    }

    private Book CreateBookFromUser()
    {
        var tittle = _userCommunicator.GetValidTittle();
        var author = _userCommunicator.GetValidAuthor();

        return new Book();
    }

    private void Exit()
    {
        Environment.Exit(0);
    }
}