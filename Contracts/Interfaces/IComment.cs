using Entities.Models;

namespace Contracts.Interfaces;

public interface IComment
{
    Task<IEnumerable<Comment>> GetAllCommentsByPost(int PostId);
    Task<Comment> GetCommentById(int PostId,int Id);
    Task<Comment> CreateComment(int PostId,Comment modelToCreate);
    Task<Comment> UpdateComment(int PostId, Comment modelToUpdate);
    Task DeleteComment(int PostId, int Id);
}