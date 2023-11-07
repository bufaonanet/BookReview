namespace BookReview.Api.Core.Entities;

public class Book
{
    public string Id { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public List<Review> BookReviews { get; private set; }

    public Book(string title, string author)
    {
        Id = Guid.NewGuid().ToString();
        Title = title;
        Author = author;
        BookReviews = new List<Review>();
    }

    public void AddReview(Review review)
    {
        BookReviews.Add(review);
    }
}