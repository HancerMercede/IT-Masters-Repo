using Contracts.Interfaces;

namespace Persistence;

public class RepositoryManager:IRepositoryManager
{
  private readonly DataContext _context;
  private readonly Lazy<IPost> _postRepositoy;
  private readonly Lazy<IComment> _commentRepository;

  public RepositoryManager(DataContext context)
  {
    _context = context;
    _postRepositoy = new Lazy<IPost>(() => new PostRepository(_context));
    _commentRepository = new Lazy<IComment>(() => new CommentRepository(_context));
  }

  public IPost Post => _postRepositoy.Value;
  
  public IComment Comment => _commentRepository.Value;
}