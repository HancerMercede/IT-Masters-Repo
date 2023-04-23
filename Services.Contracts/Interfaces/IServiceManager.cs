namespace Services.Contracts.Interfaces;

public interface IServiceManager
{
    IPostService PostService { get; }
    ICommentService CommentService { get; }
}