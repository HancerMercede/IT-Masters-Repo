using Entities.Models;

namespace Services.Contracts.Interfaces;

public interface ICommentService
{
    Task<IEnumerable<Comment>> GetAllCommentsByPost(Guid postId);
    Task<Comment> GetCommentById(Guid postId,Guid id);
    Task<Comment> CreateComment(Guid postId,Comment modelToCreate);
    Task<Comment> UpdateComment(Guid postId, Comment modelToUpdate);
    Task DeleteComment(Guid postId, Guid id);
}