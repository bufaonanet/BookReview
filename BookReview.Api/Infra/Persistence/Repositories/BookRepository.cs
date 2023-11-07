using BookReview.Api.Core.Entities;
using MongoDB.Driver;

namespace BookReview.Api.Infra.Persistence.Repositories;

public class BookRepository : IBookRepository
{
    private readonly IMongoCollection<Book> _booksCollection;

    public BookRepository(MongoDbContext dbContext)
    {
        _booksCollection = dbContext.Books;
    }

    public async Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        return await _booksCollection.Find(_ => true).ToListAsync();
    }

    public async Task<Book?> GetBookByIdAsync(string id)
    {
        return await _booksCollection.Find(book => book.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateBookAsync(Book book)
    {
        await _booksCollection.InsertOneAsync(book);
    }

    public async Task CreateReviewAsync(string bookId, Review review)
    {
        var book = await GetBookByIdAsync(bookId);
        if (book is not null)
        {
            book.AddReview(review);
            await UpdateBookAsync(bookId, book);
        }
    }


    public async Task UpdateBookAsync(string id, Book book)
    {
        var filter = Builders<Book>.Filter.Eq(b => b.Id, id);
      
        
        await _booksCollection.ReplaceOneAsync(filter, book);
    }

    public async Task DeleteBookAsync(string id)
    {
        await _booksCollection.DeleteOneAsync(b => b.Id == id);
    }
}