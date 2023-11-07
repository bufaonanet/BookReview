namespace BookReview.Api.Core.Entities;

public class Review
{
    public int Rating { get; private set; }
    public string Comment { get; private set; }
    public string UserName { get; private set; }

    public Review(int rating, string comment, string userName)
    {
        Rating = rating;
        Comment = comment;
        UserName = userName;
    }
}