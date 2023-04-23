using Contracts.Interfaces;
using Entities.Models;

namespace Persistence;

public class CommentRepository:IComment
{
    private readonly DataContext _context;

    public CommentRepository(DataContext context)
    {
        _context = context;
    }

    public Task<IEnumerable<Comment>> GetAllCommentsByPost(int PostId)
    {
        throw new NotImplementedException();
    }

    public Task<Comment> GetCommentById(int PostId, int Id)
    {
        throw new NotImplementedException();
    }

    public Task<Comment> CreateComment(int PostId, Comment modelToCreate)
    {
        throw new NotImplementedException();
    }

    public Task<Comment> UpdateComment(int PostId, Comment modelToUpdate)
    {
        throw new NotImplementedException();
    }

    public Task DeleteComment(int PostId, int Id)
    {
        throw new NotImplementedException();
    }
}