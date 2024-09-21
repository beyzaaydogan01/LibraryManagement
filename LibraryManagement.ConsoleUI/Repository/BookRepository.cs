
using LibraryManagement.ConsoleUI.Models.Dtos;

namespace LibraryManagement.ConsoleUI.Repository;

public class BookRepository
{
    List<Author> authors = new List<Author>()
{
    new Author(1,"Emile","Zola"),
    new Author(2,"Fyodor","Dostoyevski"),
    new Author(3,"Recaizade Mahmut","Ekrem"),
    new Author(4, "Halide Edib","Adıvar"),
    new Author(5,"Ömer","Seyfettin"),
    new Author(6,"Ali","Koç"),
    new Author(7,"Vız vız","Ali")
};
    List<Book> books = new List<Book>()
{
    new Book(1,1,1,"Germinal","Kömür Madeni",341,"2012 Mayıs","9781234567897"),
    new Book(2,1,2,"Suç ve Ceza","Raskolnikov un hayatı",315,"2010 Haziran","9781234567891"),
    new Book(3,1,2,"Kumarbaz","Bir Öğretmenin hayatı",210,"2009 Ocak","9781234567892"),
    new Book(4,2,3, "Araba Sevdası","Arabayla alakası olmayan Kitap",180,"1999 Ocak","9781234567838"),
    new Book(5,2,4,"Ateşten Gömlek","Kurtulu savaşını anlatan kitap",120,"2001 Eylül","9781234567834"),
    new Book(6,2,5,"Kaşağı","Okunmaması gereken bir kitap",95,"1993 Ocak","9781234567845"),
    new Book(7,3,6,"28 Şampiyonluk","Hayal ürünüdür",350,"1907 Ocak ","9781234567807"),
    new Book(8,3,6,"16 Yıl Şampiyonluk","Hayal ürünüdür.",255,"10 Eylül","9781234567800"),
    new Book(9,3,7,"Ali Arı","Uyanık Ceo nun hikayesi",551,"20 Haziran","9781234567800")
};
    List<Category> categories = new List<Category>()
{
    new Category(1,"Dünya Klasikleri"),
    new Category(2,"Türk Klasikleri"),
    new Category(3,"Bilim Kurgu")
};
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
    public List<Book> GetAllBooksOrderByTitleDescending()
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
}
