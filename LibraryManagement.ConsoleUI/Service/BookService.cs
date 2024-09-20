
using LibraryManagement.ConsoleUI.Models.Dtos;
using LibraryManagement.ConsoleUI.Repository;
using System.Threading.Channels;

namespace LibraryManagement.ConsoleUI.Service;

public class BookService
{
    BookRepository bookRepository = new BookRepository();
    public void GetAll()
    {
        List<Book> books = bookRepository.GetAll();
        books.ForEach(book => Console.WriteLine(book));
    }
    public void GetAllBooksByPageSizeFilter(int min, int max)
    {
        List<Book> books = bookRepository.GetAllBooksByPageSizeFilter(min, max);
        books.ForEach(book => Console.WriteLine(book));
    }
    public void GetAllBooksByTitleContains(string text)
    {
        List<Book> books = bookRepository.GetAllBooksByTitleContains(text);
        books.ForEach(book => Console.WriteLine(book));
    }
    public void GetBookByISBN(string isbn)
    {
        Book? book = bookRepository.GetBookByISBN(isbn);
        if(book is null)
        {
            Console.WriteLine($"Aradığınız ISBN numarasına göre bir kitap bulunamadı: {isbn}");
            return;
        }
        Console.WriteLine(book);
    }
    public void Add(Book book)
    {
        Book created = bookRepository.Add(book);
        Console.WriteLine($"Kitap eklendi: {created}");
    }
    public void GetById(int id)
    {
        Book? book = bookRepository.GetById(id);
        if(book == null)
        {
            Console.WriteLine($"Aradığınız Id ye göre kitap bulunamadı {id}");
            return;
        }
        Console.WriteLine(book);
    }
    public void Remove(int id)
    {
        Book? deletedBook = bookRepository.Remove(id);
        if(deletedBook == null)
        {
            Console.WriteLine($"Böyle bir id numarası yok: {id}");
            return;
        }
        Console.WriteLine(deletedBook);
    }
    public void GetAllBookOrderByTitle()
    {
        List<Book> books = bookRepository.GetAllBookOrderByTitle();
        books.ForEach(book=> Console.WriteLine(book));
    }
    public void GetAllBooksOrderByTitleDescending()
    {
        List<Book> books = bookRepository.GetAllBooksOrderByTitleDescending();
        books.ForEach(book => Console.WriteLine(book));
    }
    public void GetBookMaxPageSize()
    {
        Book book = bookRepository.GetBookMaxPageSize();
        Console.WriteLine(book);
    }
    public void GetBookMinPageSize()
    {
        Book book = bookRepository.GetBookMinPageSize();
        Console.WriteLine(book);
    }
    public void GetDetails()
    {
        List<BookDetailDto> bookDetail = bookRepository.GetDetails();
        bookDetail.ForEach(b =>  Console.WriteLine(b));
    }
    public void GetDetailsV2()
    {
        List<BookDetailDto> bookDetail = bookRepository.GetDetailsV2();
        bookDetail.ForEach(b => Console.WriteLine(b));
    }
}
