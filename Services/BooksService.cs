
using LibraryApi.Models;
using Serilog;

namespace LibraryApi.Services;

public class BooksService : IBooksService
{
    private static readonly List<Book> books = new()
    {
        // new Book { Id = 1, Title = "1984", Author = "George Orwell", Year = 1949 },
        // new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Year = 1960 },
    };

    public IEnumerable<Book> GetBooks() => books;

    public Book? GetBookById(int id) => books.FirstOrDefault(b => b.Id == id);
    public void AddBook(Book book)
    {
        book.Id = books.Max(b => b.Id) + 1;
        books.Add(book);
        Log.Information("Book added: {@Book}", book);
    }

    public void UpdateBook(int id, Book book)
    {
        var existingBook = GetBookById(id);
        if (existingBook == null)

        existingBook.Title = book.Title;
        existingBook.Author = book.Author;
        existingBook.Year = book.Year;

    }

    public void DeleteBook(int id)
    {
        var book = GetBookById(id);
        if (book != null)
            books.Remove(book);
    }
}