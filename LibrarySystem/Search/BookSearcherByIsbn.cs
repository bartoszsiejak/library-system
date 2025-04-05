﻿using LibrarySystem.DataStructures;
using LibrarySystem.Models;
using LibrarySystem.Models.BookModel;
using LibrarySystem.UserCommunication;
using LibrarySystem.Validation;

namespace LibrarySystem.Search;

public class BookSearcherByIsbn(
    IUserCommunicator userCommunicator,
    IBookValidator bookValidator) 
    : IBookSearcher
{
    private readonly IUserCommunicator _userCommunicator = userCommunicator;
    private readonly IBookValidator _bookValidator = bookValidator;

    public IEnumerable<Book> Search(IBookStorage bookStorage)
    {
        var isbn = _userCommunicator.ReadValidFromUser("ISBN", _bookValidator.IsValidAuthor);
        return bookStorage.Books.Where(book => book.Isbn == isbn);
    }
}