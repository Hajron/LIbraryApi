
using LibraryApi.Models;
using LibraryApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers;



[ApiController]
[Route("api/[controller]")]

public class BooksController : ControllerBase
{

    private readonly IBooksService _booksService;

    public BooksController(IBooksService booksService)
    {
        _booksService = booksService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Book>> GetBooks()
    {
        var books = _booksService.GetBooks();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public ActionResult<Book> GetBook(int id)
    {
        var book = _booksService.GetBookById(id);
        if (book == null)
        {
            return NotFound();
        }
        return Ok(book);
    }

    [HttpPost]
    public ActionResult<Book> CreateBook(Book newBook)
    {
        _booksService.AddBook(newBook);
        return CreatedAtAction(nameof(GetBook), new { id = newBook.Id }, newBook);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateBook(int id, Book updatedBook)
    {
        var existingBook = _booksService.GetBookById(id);
        if (existingBook == null)
        {
            return NotFound();
        }
        _booksService.UpdateBook(id, updatedBook);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteBook(int id)
    {
        _booksService.DeleteBook(id);
        return NoContent();
     }

}