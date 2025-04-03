﻿namespace LibrarySystem.UserCommunication;

public class ConsoleUserCommunicator(
    IConsole consoleWrapper) 
    : IUserCommunicator
{
    private readonly IConsole _consoleWrapper = consoleWrapper;
    
    public char ReadOptionFromUser()
    {
        return _consoleWrapper.ReadKey(true).KeyChar;
    }

    public string ReadStringFromUser()
    {
        return _consoleWrapper.ReadLine() ?? string.Empty;
    }

    public void Print(string message)
    {
        _consoleWrapper.WriteLine(message);
    }

    public void ClearWindow()
    {
        _consoleWrapper.Clear();
    }

    public void WaitForKey()
    {
        _consoleWrapper.WriteLine("Press any key to continue...");
        _consoleWrapper.ReadKey(true);
    }
}