using LibraryManagement.ConsoleUI.Models;

namespace LibraryManagement.ConsoleUI;

public sealed class Author : Entity
{
    public Author()
    {

    }
    public Author(int id, string name, string surname) : base(id)
    {
        Name = name;
        Surname = surname;
    }
    public string Name { get; set; }
    public string Surname { get; set; }
}