
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
}
