namespace LibrarySystem.File;

public class FileWrapper : IFile
{
    public bool IsExist(string path) => System.IO.File.Exists(path);
    
    public void Save(string path, string content) => System.IO.File.WriteAllText(path, content);
    
    public string Load (string path) => System.IO.File.ReadAllText(path);
        
}