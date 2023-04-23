namespace Dtos.Dtos;

public record PostDto()
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Image { get; set; }
    public DateTime PostDate { get; set; }
    public string CreateBy { get; set; } 
}