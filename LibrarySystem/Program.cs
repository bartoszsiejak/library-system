using LibrarySystem;

try
{
    new LibrarySystemApp()
        .Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.ReadKey();
}