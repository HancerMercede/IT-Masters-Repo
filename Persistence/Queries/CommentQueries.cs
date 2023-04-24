namespace Persistence.Queries;

public static class CommentQueries
{
    public const string GetAllCommentsByPost = @"SELECT Id, Content, UserName, CommentDate
                                                     FROM Comments
                                                 WHERE PostId = @postId";
    
    public const string GetCommentByIdForPost = @"SELECT Id, Content, UserName, CommentDate
                                                     FROM Comments
                                                 WHERE PostId = @postId AND Id =@commentId";

    public const string CreateCommentForPost = @"INSERT INTO Comments (Content, UserName, CommentDate, PostId) OUTPUT INSERTED.Id
                                               VALUES (@content,  @username, @commentdate,@postid)";
    
    public const string UpdateCommentForPost = @"UPDATE Comments SET Content = @content WHERE PostId = @postId AND Id =@id";
    
    public const string DeleteCommentForPost = @"DELETE Comments WHERE PostId = @postId AND Id =@id";
}
