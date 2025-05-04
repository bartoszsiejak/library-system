namespace LibrarySystem.File;

public interface IFile
{
    bool IsExist(string path);
    void Save(string path, string content);
    string Load(string path);
}