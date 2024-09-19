
namespace LibraryManagement.ConsoleUI.Repository;

public class BookRepository
{
    List<Book> books = new List<Book>()
{
    new Book(1,1,"Germinal","Kömür Madeni",341,"2012 Mayıs","9781234567897"),
    new Book(2,1,"Suç ve Ceza","Raskolnikov un hayatı",315,"2010 Haziran","9781234567891"),
    new Book(3,1,"Kumarbaz","Bir Öğretmenin hayatı",210,"2009 Ocak","9781234567892"),
    new Book(4,2, "Araba Sevdası","Arabayla alakası olmayan Kitap",180,"1999 Ocak","9781234567838"),
    new Book(5,2,"Ateşten Gömlek","Kurtulu savaşını anlatan kitap",120,"2001 Eylül","9781234567834"),
    new Book(6,2,"Kaşağı","Okunmaması gereken bir kitap",95,"1993 Ocak","9781234567845"),
    new Book(7,3,"28 Şampiyonluk","Hayal ürünüdür",350,"1907 Ocak ","9781234567807"),
    new Book(8,3,"16 Yıl Şampiyonluk","Hayal ürünüdür.",255,"10 Eylül","9781234567800"),
    new Book(9,3,"Ali Arı","Uyanık Ceo nun hikayesi",551,"20 Haziran","9781234567800")
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

}
