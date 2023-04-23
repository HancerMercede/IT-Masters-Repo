﻿using Contracts.Interfaces;
using Entities.Models;
using Services.Contracts.Interfaces;

namespace Services;

public sealed class CommentService:ICommentService
{
    private readonly IRepositoryManager _repositoryManager;

    public CommentService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    
    public async Task<IEnumerable<Comment>> GetAllCommentsByPost(Guid postId)
    {
        return await _repositoryManager.Comment.GetAllCommentsByPost(postId);
    }

    public async Task<Comment> GetCommentById(Guid postId, Guid id)
    {
        return await _repositoryManager.Comment.GetCommentById(postId, id);
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