#nullable disable
namespace Entities.Models;

public record Comment
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public string UserName { get; set; }
    public DateTime CommentDate { get; set; }
}
