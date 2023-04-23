namespace Dtos.Dtos;

public record CommentDto
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public string UserName { get; set; }
    public DateTime CommentDate { get; set; }
}