using Contracts.Interfaces;
using Services.Contracts.Interfaces;

namespace Services;

public class ServiceManager:IServiceManager
{
    private readonly Lazy<IPostService> _PostService;
    private readonly Lazy<ICommentService> _CommentService;
    public ServiceManager(IRepositoryManager repositoryManager)
    {
        _PostService = new Lazy<IPostService>(() => new PostService(repositoryManager));
        _CommentService = new Lazy<ICommentService>(() => new CommentService(repositoryManager));
    }

    public IPostService PostService => _PostService.Value;
    public ICommentService CommentService => _CommentService.Value;
}
