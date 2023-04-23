using Contracts.Interfaces;
using Dapper;
using Entities.Models;
using Persistence.Queries;

namespace Persistence;

public class PostRepository:IPost
{
    private readonly DataContext _context;

    public PostRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Post>> GetAllPost()
    {
        var query = PostQueries.GettingAllPosts;
        using(var connection = _context.CreateConnection())
        {
            var posts = await connection.QueryAsync<Post>(query);
            return posts;
        }
    }


    public async Task<Post> GetPostById(Guid Id)
    {
        var query = PostQueries.GetPostById;
        
        var parameters = new DynamicParameters();
        parameters.Add("id",Id);
        
        using (var connection = _context.CreateConnection())
        {
            var post = await connection.QueryFirstOrDefaultAsync<Post>(query, parameters);
            return post;
        }
    }

    public async Task<Post> CreatePost(Post modelToCreate)
    {
        var query = PostQueries.CreatePost;
        var parameters = new DynamicParameters();
        parameters.Add("title",modelToCreate.Title);
        parameters.Add("content",modelToCreate.Content);
        parameters.Add("image",modelToCreate.Image);
        parameters.Add("postdate",modelToCreate.PostDate);
        parameters.Add("createby",modelToCreate.CreateBy);
        using (var connection = _context.CreateConnection())
        {
            var postId = await connection.ExecuteScalarAsync<Guid>(query, parameters);

            return new Post
            {
                Id = postId,
                Title = modelToCreate.Title,
                Content = modelToCreate.Content,
                Image = modelToCreate.Image,
                PostDate = modelToCreate.PostDate,
                CreateBy = modelToCreate.CreateBy
            };
        }
    }

    public async Task<Post> UpdatePost(Guid Id, Post modelToUpdate)
    {
        var query = PostQueries.UpdatePost;
        
        var parameters = new DynamicParameters();
        parameters.Add("title",modelToUpdate.Title);
        parameters.Add("content",modelToUpdate.Content);
        parameters.Add("image",modelToUpdate.Image);
        parameters.Add("id", Id);
        
        
        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(query, parameters);

        return new Post
        { 
            Id = Id,
            Title = modelToUpdate.Title, 
            Content = modelToUpdate.Content,
            Image = modelToUpdate.Image,
            PostDate = modelToUpdate.PostDate,
            CreateBy = modelToUpdate.CreateBy

        };
    }

    public async Task DeletePost(int Id)
    {
        var query = PostQueries.DeletePost;
        
    }
}