using Entities.Models;
// ReSharper disable All

namespace Services.Contracts.Interfaces;

public interface IPostService
{
    Task<IEnumerable<Post>> GetAllPost();
    Task<Post> GetPostById(Guid Id);
    Task<Post> CreatePost(Post modelToCreate);
    Task<Post> UpdatePost(Guid Id, Post modelToUpdate);
    Task DeletePost(int Id);
}