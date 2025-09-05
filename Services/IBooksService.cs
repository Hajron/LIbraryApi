
using LibraryApi.Models;
public interface IBooksService
{
    IEnumerable<Book> GetBooks();
    Book? GetBookById(int ID);
    void AddBook(Book book);
    void UpdateBook(int Id, Book book);
    void DeleteBook(int id);
}