using Entities.Models;

namespace Contracts.Interfaces;

public interface IPost
{
    Task<IEnumerable<Post>> GetAllPost();
    Task<Post> GetPostById(Guid Id);
    Task<Post> CreatePost(Post modelToCreate);
    Task<Post> UpdatePost(Guid Id, Post modelToUpdate);
    Task DeletePost(int Id);
}