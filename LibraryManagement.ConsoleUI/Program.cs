//(Record) Kitap -> Id,Title , Description, PageSize, PublishDate, ISBN , Stock
//(Record) Author -> Id,Name, Surname
//(Class) Category -> Id,Name 


//Kitaplar listesi oluşturunuz
//Yazarlar   "         "
//Kategoriler  "       "        


// Yazarları ekrana bastıran kodu yazınız
// Kitapları ekrana bastıran kodu yazınız
// Kategorileri ekrana bastıran kodu yazınız.

// Kitapları Sayfa sayısına göre filtreleyen kodu yazınız.
// Kütüphanedeki tüm kitapların sayfa sayısı toplamını hesaplayan kodu yazınız.
// Kitap başlığına göre filtreleme  işlemleri yapınız
// Kitap ISBN numarasına göre ilgili kitabı getiriniz.

// Kitaplar listesine yeni bir kitap ekleyip eklendikten sonra listeyi ekran çıktısı
// olarak veriniz.(Verileri kullanıcıdan alınız.)
// * Kitap eklerken Id si veya ISBN numarası daha önceki eklenen kitaplarda var ise 
// Benzersiz bir kitap girmeniz gerekmektedir yazısı çıksın.

// Kullanıcı bir Id girdiği zaman o id ye göre kitabı silen ve yeni listeyi ekrana bastıran
// kodu yazınız.


// Kullanıcıdan ilk başta id değeri alıp arama yaptıktan sonra eğer o Id ye ait
// bir kitap yoksa "İlgili Id ye ait bir kitap bulunamadı."
//* Güncellenecek olan değerler kullanıcıdan alınacak.

// Kullanıcıdan bir kitap almasını isteyen kodu yazınız 
// Eğer o kitap Stok da varsa kitap alındı yazısı çıksın 
// 1 tane varsa o kitap alınsın ve 0 olursa Listeden silinsin.



// Prime Örnekler 
// BookDetail adında bir record oluşturup şu değerler listelenecek
// Kitap Id, Kitap Başlığı , Kitap Açıklaması, Kitap Sayfa Sayısı, ISBN ,
// Yazar Adı, Kategori Adı


// Kullanıcıdan PageIndex ve PageSize değerlerini alarak sayfalama desteği getiriniz.


using LibraryManagement.ConsoleUI.Models;
using LibraryManagement.ConsoleUI.Service;
using System.ComponentModel;

BookService bookService = new BookService();

//bookService.GetAll();
//bookService.GetAllBooksByPageSizeFilter(100,200);
//bookService.GetAllBookOrderByTitle();
//bookService.GetAllBooksOrderByTitleDescending();
//bookService.GetBookMinPageSize();
//bookService.GetBookMaxPageSize();
//bookService.GetDetails();




