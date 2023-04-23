using Entities.Models;

namespace Contracts.Interfaces;

public interface IPost
{
    Task<IEnumerable<Post>> GetAllPost();
    Task<Post> GetPostById(Guid id);
    Task<Post> CreatePost(Post modelToCreate);
    Task<Post> UpdatePost(Guid id, Post modelToUpdate);
    Task DeletePost(Guid id);
}