using Contracts.Interfaces;
using Entities.Models;
using Services.Contracts.Interfaces;
// ReSharper disable All

namespace Services;

public sealed class PostService:IPostService
{
    private readonly IRepositoryManager _repositoryManager;

    public PostService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<IEnumerable<Post>> GetAllPost()
    {
        var posts = await _repositoryManager.Post.GetAllPost();
        return posts;
    }

    public async Task<Post> GetPostById(Guid Id)
    {
        return await _repositoryManager.Post.GetPostById(Id);
    }

    public async Task<Post> CreatePost(Post modelToCreate)
    {
        var result = await _repositoryManager.Post.CreatePost(modelToCreate);
        return result;
    }

    public async Task<Post> UpdatePost(Guid Id, Post modelToUpdate)
    {
        return await _repositoryManager.Post.UpdatePost(Id, modelToUpdate);
    }

    public async Task DeletePost(Guid Id)
    {
        await _repositoryManager.Post.DeletePost(Id);
    }
}