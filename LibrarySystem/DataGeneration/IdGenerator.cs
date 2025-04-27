using LibrarySystem.Menus.Options.CustomerOption;

namespace LibrarySystem.DataGeneration;

public class IdGenerator(uint id) : IIdGenerator
{
    private uint _id = id;

    public uint GetId()
    {
        checked
        {
            return _id++;
        }
    }
}