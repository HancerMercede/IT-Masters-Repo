using Contracts.Interfaces;
using Entities.Models;
using Services.Contracts.Interfaces;

namespace Services;

public class CommentService:ICommentService
{
    private readonly IRepositoryManager _repositoryManager;

    public CommentService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
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