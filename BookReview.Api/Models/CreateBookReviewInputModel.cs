namespace BookReview.Api.Models;

public class CreateBookReviewInputModel
{
    public int Rating { get; set; }
    public string Commnet { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;

}