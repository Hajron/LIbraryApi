using LibraryApi.Controllers;
using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using System.Linq;
using System.Collections.Generic;

public class BooksControllerTests
{
    public BooksControllerTests()
    {
        BooksController.ResetBooks();
    }

    [Fact]
    public void GetBooks_ReturnsAllBooks()
    {
        var controller = new BooksController();

        var result = controller.GetBooks();

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var books = Assert.IsAssignableFrom<IEnumerable<Book>>(okResult.Value);
        Assert.True(books.Count() >= 2);
    }

    [Fact]
    public void GetBook_ReturnsBook_WhenBookExists()
    {
        var controller = new BooksController();

        var result = controller.GetBook(1);

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var book = Assert.IsType<Book>(okResult.Value);
        Assert.Equal(1, book.Id);
    }

    [Fact]
    public void GetBook_ReturnsNotFound_WhenBookDoesNotExist()
    {
        var controller = new BooksController();

        var result = controller.GetBook(999);

        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public void CreateBook_AddsBook()
    {
        var controller = new BooksController();
        var newBook = new Book { Title = "Test", Author = "Tester", Year = 2024 };

        var result = controller.CreateBook(newBook);

        var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
        var book = Assert.IsType<Book>(createdResult.Value);
        Assert.Equal("Test", book.Title);
    }

    [Fact]
    public void UpdateBook_UpdatesBook_WhenBookExists()
    {
        var controller = new BooksController();
        var updatedBook = new Book { Title = "Updated", Author = "Updated", Year = 2025 };

        var result = controller.UpdateBook(1, updatedBook);

        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public void UpdateBook_ReturnsNotFound_WhenBookDoesNotExist()
    {
        var controller = new BooksController();
        var updatedBook = new Book { Title = "Updated", Author = "Updated", Year = 2025 };

        var result = controller.UpdateBook(999, updatedBook);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void DeleteBook_DeletesBook_WhenBookExists()
    {
        var controller = new BooksController();

        var result = controller.DeleteBook(1);

        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public void DeleteBook_ReturnsNotFound_WhenBookDoesNotExist()
    {
        var controller = new BooksController();

        var result = controller.DeleteBook(999);

        Assert.IsType<NotFoundResult>(result);
    }
}