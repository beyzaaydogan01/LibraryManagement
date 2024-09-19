namespace LibraryManagement.ConsoleUI;

public record Book(
    int Id,
    int CategoryId,
    string Title,
    string Description,
    int PageSize,
    string PublishDate,
    string ISBN
    );