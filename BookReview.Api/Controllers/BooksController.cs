using BookReview.Api.Core.Entities;
using BookReview.Api.Infra.Persistence.Repositories;
using BookReview.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookReview.Api.Controllers;

[Route("api/books")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookRepository _bookRepository;

    public BooksController(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks()
    {
        var books = await _bookRepository.GetAllBooksAsync();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBook(string id)
    {
        var book = await _bookRepository.GetBookByIdAsync(id);
        if (book == null)
        {
            return NotFound();
        }

        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook(CreateBookInputModel model)
    {
        var book = new Book(model.Title, model.Author);

        await _bookRepository.CreateBookAsync(book);

        return CreatedAtAction("GetBook", new { id = book.Id }, book);
    }

    [HttpPost("{id}/review")]
    public async Task<IActionResult> CreateReview(string id, CreateBookReviewInputModel model)
    {
        var review = new Review(model.Rating, model.Commnet, model.UserName);

        await _bookRepository.CreateReviewAsync(id, review);

        return NoContent();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(string id, [FromBody] Book book)
    {
        var existingBook = await _bookRepository.GetBookByIdAsync(id);
        if (existingBook == null)
        {
            return NotFound();
        }
        await _bookRepository.UpdateBookAsync(id, book);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(string id)
    {
        var existingBook = await _bookRepository.GetBookByIdAsync(id);
        if (existingBook == null)
        {
            return NotFound();
        }
        await _bookRepository.DeleteBookAsync(id);
        return NoContent();
    }
}