using Contracts.Interfaces;
using Dapper;
using Entities.Models;
using Persistence.Queries;

namespace Persistence;

public sealed class CommentRepository:IComment
{
    private readonly DataContext _context;

    public CommentRepository(DataContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<Comment>> GetAllCommentsByPost(Guid postId)
    {
        var query = CommentQueries.GetAllCommentsByPost;
        
        var parameters = new DynamicParameters();
        parameters.Add("postId", postId);
        
        using var connection = _context.CreateConnection();
        var comments = await  connection.QueryAsync<Comment>(query, parameters);

        return comments;

    }

    public async Task<Comment> GetCommentById(Guid postId, Guid id)
    {
        var query = CommentQueries.GetAllCommentsByPost;
        
        var parameters = new DynamicParameters();
        parameters.Add("postId", postId);
        parameters.Add("Id", id);
        using var connection = _context.CreateConnection();
        var comment = await  connection.QueryFirstAsync<Comment>(query, parameters);

        return comment;
    }

    public async Task<Comment> CreateComment(Guid postId, Comment modelToCreate)
    {
        var query = CommentQueries.CreateCommentForPost;
        
        var parameters = new DynamicParameters();
        parameters.Add("content", modelToCreate.Content);
        parameters.Add("username", modelToCreate.UserName);
        parameters.Add("commentdate", modelToCreate.CommentDate);
        parameters.Add("postid", postId);

        var connection = _context.CreateConnection();

        var id = await connection.ExecuteScalarAsync<Guid>(query, parameters);
        return new Comment
        {
            Id = id, 
            Content = modelToCreate.Content, 
            UserName = modelToCreate.UserName,
            CommentDate = modelToCreate.CommentDate
        };
    }

    public async Task<Comment> UpdateComment(Guid postId, Guid id, Comment modelToUpdate)
    {
        var query = CommentQueries.UpdateCommentForPost;
        
        var parameters = new DynamicParameters();
        parameters.Add("content", modelToUpdate.Content);
        parameters.Add("postid", postId);
        parameters.Add("Id", id);

        var connection = _context.CreateConnection();

        await connection.ExecuteAsync(query, parameters);
        return new Comment
        {
            Id = id, 
            Content = modelToUpdate.Content, 
            UserName = modelToUpdate.UserName
        };
    }

    public async Task DeleteComment(Guid postId, Guid id)
    {
        var query = CommentQueries.DeleteCommentForPost;

        var parameters = new DynamicParameters();
        
        parameters.Add("postId", postId);
        parameters.Add("Id", id);

        var connection = _context.CreateConnection();

        await connection.ExecuteAsync(query, parameters);
    }
}