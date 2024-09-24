
using LibraryManagement.ConsoleUI.Models.Dtos;

namespace LibraryManagement.ConsoleUI.Repository;

public class BookRepository:BaseRepository, IBookRepository
{
    private List<Book> books;
    private List<Category> categories;
    private List<Author> authors;
    public BookRepository()
    {
        books = Books();
        categories = Categories();
        authors = Authors();
    }

    public List<Book> GetAll()
    {
        return books;
    }
    public List<Book> GetAllBooksByPageSizeFilter(int min, int max)
    {
        /* //Geleneksel Yöntem
         List<Book> filteredBooks = new List<Book>();
         foreach(Book book in books)
         {
             if(book.PageSize <= max && book.PageSize >= min){
                 filteredBooks.Add(book);
             }
         }
         return filteredBooks;*/

        /*//LINQ Geleneksel Yöntem
        List<Book> result = (from b in books
                             where  b.PageSize >= min && b.PageSize <= max
                             select b).ToList();
        return result;*/

        //List<Book> result = books.Where(b => b.PageSize <= max && b.PageSize >= min).ToList();

        List<Book> result = books.FindAll(b => b.PageSize <= max && b.PageSize >= min);
        return result;
    }
    public double PageSizeTotalCalculator()
    {
        double total = books.Sum(b => b.PageSize);
        return total;
    }
    public List<Book> GetAllBooksByTitleContains(string text)
    {
       /* List<Book> titleContainsBook = new List<Book>();
        foreach (Book book in books)
        {
            if (book.Title.Contains(text, StringComparison.InvariantCultureIgnoreCase))
            {
                titleContainsBook.Add(book);
            }
        }
        return titleContainsBook;*/
       List<Book> result = books.FindAll(b => b.Title.Contains(text, StringComparison.InvariantCultureIgnoreCase));
        return result;
    }
    public Book? GetBookByISBN(string isbn)
    {
        /*Book? book1 = null;
        foreach(Book item in books)
        {
            if(item.ISBN == isbn)
            {
                book1 = item;
            }
        }
        if(book1 == null)
        {
            return null;
        }
        return book1;*/

        Book book = books.SingleOrDefault(x => x.ISBN == isbn);
        return book;
    }
    public Book Add(Book created)
    {
        books.Add(created);
        return created;
    }
    public Book? GetById(int id)
    {
        Book book1 = null;
        foreach(Book book in books){
            if(book.Id == id)
            {
                book1 = book;
            }
        }
        if(book1 == null)
        {
            return null;
        }
        return book1;
    }
    public Book? Remove(int id)
    {
        Book? deletedBook = GetById(id);
        if(deletedBook is null)
        {
            return null;
        }
        books.Remove(deletedBook);
        return deletedBook;
    }
    public List<Book> GetAllBookOrderByTitle()
    {
        List<Book> orderedBooks = books.OrderBy(b => b.Title).ToList();
        return orderedBooks;
    }
    public List<Book> GetAllBookOrderByDescendingTitle()
    {
        List<Book> orderedBooks = books.OrderByDescending(b => b.Title).ToList();
        return orderedBooks;
    }
    public Book GetBookMaxPageSize()
    {
        Book maxPageSize = books.OrderBy(b=> b.PageSize).LastOrDefault();
        return maxPageSize;
    }
    public Book GetBookMinPageSize()
    {
        Book minPageSize = books.OrderByDescending(b => b.PageSize).LastOrDefault();
        return minPageSize;
    }
    public List<BookDetailDto> GetDetails()
    {
        var result = from b in books
                     join c in categories
                     on b.CategoryId equals c.Id
                     select new BookDetailDto(
                         Id: b.Id,
                         CategoryName: c.Name,
                         "",
                         Title: b.Title, 
                         Description: b.Description,
                         PageSize: b.PageSize,
                         PublishDate: b.PublishDate,
                         ISBN: b.ISBN);
        return result.ToList();
    }
    public List<BookDetailDto> GetDetailsV2()
    {
        List<BookDetailDto> bookDetails = books.Join(categories,
            b => b.CategoryId,
            c => c.Id,
            (book, category) => new BookDetailDto(
                Id: book.Id,
                CategoryName: category.Name,
                "",
                Title: book.Title,
                Description: book.Description,
                PageSize: book.PageSize,
                PublishDate: book.PublishDate,
                ISBN: book.ISBN
                )
            ).ToList();
        return bookDetails;
    }
    public List<BookDetailDto> GetAllAuthorAndBookDetails()
    {
        var result = from b in books
                     join c in categories on b.CategoryId equals c.Id
                     join a in authors on b.AuthorId equals a.Id
                     select new BookDetailDto(
                         Id: b.Id,
                         CategoryName: c.Name,
                         AuthorName: $"{a.Name} {a.Surname}",
                         Title: b.Title,
                         Description: b.Description,
                         PageSize: b.PageSize,
                         PublishDate: b.PublishDate,
                         ISBN: b.ISBN
                         );
        return result.ToList();
    }
    public List<BookDetailDto> GetAllDetailsByCategoryId(int categoryId)
    {
        var result = from b in books
                     where b.CategoryId == categoryId
                     join c in categories on b.CategoryId equals c.Id
                     join a in authors on b.AuthorId equals a.Id
                     select new BookDetailDto(
                          Id: b.Id,
                          Title: b.Title,
                          CategoryName: c.Name,
                          AuthorName: $"{a.Name} {a.Surname}",
                          Description: b.Description,
                          PageSize: b.PageSize,
                          PublishDate: b.PublishDate,
                          ISBN: b.ISBN
                          );

        return result.ToList();
    }
    public List<string> GetAllTitles()
    {
        List<string> titles =
            books.Select(x=> x.Title).ToList();

        return titles;
    }
}
