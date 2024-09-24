using LibraryManagement.ConsoleUI.Models;

namespace LibraryManagement.ConsoleUI;

public sealed class Category : Entity
{
    public Category()
    {

    }
    public Category(int id, string name) :base(id)
    {
        Id = id;
        Name = name;
    }

    public string Name { get; set; }

    public override string ToString()
    {
        return $"Id : {Id}, Name: {Name}";
    }
}