using LibraryApi.Controllers;
using LibraryApi.Models;
using LibraryApi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using System.Collections.Generic;

public class BooksControllerTests
{
    private readonly Mock<IBooksService> _mockService;
    private readonly BooksController _controller;

    public BooksControllerTests()
    {
        _mockService = new Mock<IBooksService>();
        _controller = new BooksController(_mockService.Object);
    }

    [Fact]
    public void GetBooks_ReturnsAllBooks()
    {
        var books = new List<Book>
        {
            new Book { Id = 1, Title = "1984", Author = "George Orwell", Year = 1949 },
            new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Year = 1960 }
        };
        _mockService.Setup(s => s.GetBooks()).Returns(books);

        var result = _controller.GetBooks();

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedBooks = Assert.IsAssignableFrom<IEnumerable<Book>>(okResult.Value);
        Assert.Equal(2, ((List<Book>)returnedBooks).Count);
    }

    [Fact]
    public void GetBook_ReturnsBook_WhenBookExists()
    {
        var book = new Book { Id = 1, Title = "1984", Author = "George Orwell", Year = 1949 };
        _mockService.Setup(s => s.GetBookById(1)).Returns(book);

        var result = _controller.GetBook(1);

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedBook = Assert.IsType<Book>(okResult.Value);
        Assert.Equal(1, returnedBook.Id);
    }

    [Fact]
    public void GetBook_ReturnsNotFound_WhenBookDoesNotExist()
    {
        _mockService.Setup(s => s.GetBookById(999)).Returns((Book)null);

        var result = _controller.GetBook(999);

        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public void CreateBook_AddsBook()
    {
        var newBook = new Book { Id = 3, Title = "Test", Author = "Tester", Year = 2024 };
        _mockService.Setup(s => s.AddBook(newBook));

        var result = _controller.CreateBook(newBook);

        var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
        var returnedBook = Assert.IsType<Book>(createdResult.Value);
        Assert.Equal("Test", returnedBook.Title);
    }

    [Fact]
    public void UpdateBook_UpdatesBook_WhenBookExists()
    {
        var updatedBook = new Book { Id = 1, Title = "Updated", Author = "Updated", Year = 2025 };
        _mockService.Setup(s => s.GetBookById(1)).Returns(updatedBook);
        _mockService.Setup(s => s.UpdateBook(1, updatedBook));

        var result = _controller.UpdateBook(1, updatedBook);

        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public void UpdateBook_ReturnsNotFound_WhenBookDoesNotExist()
    {
        var updatedBook = new Book { Id = 999, Title = "Updated", Author = "Updated", Year = 2025 };
        _mockService.Setup(s => s.GetBookById(999)).Returns((Book)null);

        var result = _controller.UpdateBook(999, updatedBook);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void DeleteBook_DeletesBook_WhenBookExists()
    {
        _mockService.Setup(s => s.DeleteBook(1));

        var result = _controller.DeleteBook(1);

        Assert.IsType<NoContentResult>(result);
    }
}