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
        throw new NotImplementedException();
    }

    public async Task<Comment> UpdateComment(Guid postId, Comment modelToUpdate)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteComment(Guid postId, Guid id)
    {
        throw new NotImplementedException();
    }
}