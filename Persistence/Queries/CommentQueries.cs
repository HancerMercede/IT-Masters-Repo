namespace Persistence.Queries;

public static class CommentQueries
{
    public const string GetAllCommentsByPost = @"SELECT Id, Content, UserName, CommentDate
                                                     FROM Comments
                                                 WHERE PostId = @postId";
    
    public const string GetCommentByIdForPost = @"SELECT Id, Content, UserName, CommentDate
                                                     FROM Comments
                                                 WHERE PostId = @postId AND Id =@commentId";
}