namespace BlogApi.Entities;

public class Comment
{
    public int Id { get; set; }
    public string? Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsOccult { get; set; }
    public int AuthorId { get; set; }
    public int PostId { get; set; }
    public User? Author { get; set; }
    public Post? Post { get; set; }
}