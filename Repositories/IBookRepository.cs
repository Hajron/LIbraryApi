
using LibraryApi.Models;

namespace LibraryApi.Repositories;

public interface IBookRepository
{
    IQueryable<Book> GetAll();
    Book? GetBookById(int id);
    void AddBook(Book book);
    void UpdateBook(Book book);
    void DeletBook(int id);
}
