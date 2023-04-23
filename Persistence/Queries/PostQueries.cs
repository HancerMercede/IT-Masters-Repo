namespace Persistence.Queries;

public static class PostQueries
{
    public const string GettingAllPosts = @"SELECT Id, Title, Content,Image,PostDate,CreateBy 
                                               FROM Posts";
    
    public const string GetPostById = @"SELECT Id, Title, Content,Image,PostDate,CreateBy 
                                               FROM Posts
                                         WHERE Id = @id";

    public const string CreatePost = @"INSERT INTO Posts (Title, Content,Image ,PostDate, CreateBy) 
                                              OUTPUT INSERTED.Id
                                       VALUES(@title,@content,@image,@postdate,@createby)";

    public const string UpdatePost = @"UPDATE Posts SET Title = @title, Content = @content, Image=@image
                                       WHERE Id= @id";

    public const string DeletePost = @"DELETE POST WHERE Id = @id";
}