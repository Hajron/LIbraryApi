
using LibraryApi.Data;
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Repositories;

public class BookRepository : IBookRepository
{

    private readonly LibraryDbContext _context;
    
    public BookRepository(LibraryDbContext context)
    {
        _context = context;
    }

    public IQueryable<Book> GetAll()
    {
        return _context.Books
            .Include(b => b.Author)
            .Include(b => b.Loans);   
    }

    public Book? GetBookById(int id)
    {
        return _context.Books
            .Include(b => b.Author)
            .Include(b => b.Loans)
            .FirstOrDefault(b => b.Id == id);
    }

    public void AddBook(Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();
    }

    public void UpdateBook(Book book)
    {
        _context.Books.Update(book);
        _context.SaveChanges();
    }

    public void DeletBook(int id)
    {
        var book = GetBookById(id);
        if (book != null)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
 
}

