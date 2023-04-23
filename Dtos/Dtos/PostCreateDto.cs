namespace Dtos.Dtos;

public record PostCreateDto(string Title, string Content, string Image, DateTime PostDate, string CreateBy);