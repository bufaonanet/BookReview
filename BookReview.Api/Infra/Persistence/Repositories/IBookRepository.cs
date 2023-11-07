using BookReview.Api.Core.Entities;

namespace BookReview.Api.Infra.Persistence.Repositories;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllBooksAsync();
    Task<Book?> GetBookByIdAsync(string id);
    Task CreateBookAsync(Book book);
    Task CreateReviewAsync(string bookId, Review review);
    Task UpdateBookAsync(string id, Book book);
    Task DeleteBookAsync(string id);
}