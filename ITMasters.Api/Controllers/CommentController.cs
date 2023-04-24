﻿using FluentMigrator;

namespace ITMasters.Api.Controllers;

[ApiController]
[Route("api/v1/Post/{postId:guid}/[controller]")]
public class CommentController : ControllerBase
{
    private readonly IServiceManager _serviceManager;
    private readonly ILogger<CommentController> _logger;
    

    public CommentController(IServiceManager serviceManager,ILogger<CommentController> logger)
    {
        _serviceManager = serviceManager;
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(200)]
    public async Task<ActionResult<IEnumerable<CommentDto>>> GetAllCommentByPost(Guid postId)
    {
        var comments = await _serviceManager.CommentService.GetAllCommentsByPost(postId);

        if (!comments.Any())
        {
            _logger.LogInformation("There is nothing in the db yet, please create some new.");
            return NotFound("There is nothing in the db yet, please create some new.");
        }
  
        var commentsDtos = comments.Adapt<IEnumerable<CommentDto>>();

        return Ok(commentsDtos);
    }
    
    [HttpGet("{id:guid}", Name = "GetCommentById")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<IEnumerable<CommentDto>>> GetCommentByIdForPost(Guid postId, Guid id)
    {
        var comment = await _serviceManager.CommentService.GetCommentById(postId, id);

        if (comment is null)
        {
            _logger.LogInformation($"There is nothing in the with this id: {id}, please create some new.");
            return NotFound($"There is nothing in the with this id: {id}, please create some new.");
        }
  
        var commentsDtos = comment.Adapt<CommentDto>();

        return Ok(commentsDtos);
    }

    [HttpPost("CreateComment")]
    public async Task<ActionResult<CommentDto>> CreateComment(Guid postId, [FromBody] CommentCreateDto modelToCreate)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogInformation("The model is not valid");
            return StatusCode(422);
        }

        var comment = modelToCreate.Adapt<Comment>();
        
        var commentDb = await _serviceManager.CommentService.CreateComment(postId, comment);

        var commentDto = commentDb.Adapt<CommentDto>();

        return new CreatedAtRouteResult("GetCommentById", new { postId = postId, id = commentDto.Id }, commentDto);
        
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<CommentDto>> UpdateComment(Guid postId, Guid id, [FromBody] CommentUpdateDto modelToUpdate)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogInformation("The model is not valid.");
            return StatusCode(422);
        }

        var existComment = await _serviceManager.CommentService.GetCommentById(postId, id);

        if (existComment is null)
        {
            _logger.LogInformation($"There is no comment int the db with this id: {id}, please verify.");
             return NotFound($"There is no comment int the db with this id: {id}, please verify.");
        }

        existComment.Content = modelToUpdate.Content;

        var commentdb = modelToUpdate.Adapt(existComment);
        
        var commentResult = await _serviceManager.CommentService.UpdateComment(postId,id, commentdb);

        var commentDto = commentResult.Adapt<CommentDto>();

        return Ok(commentDto);

    }
    
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(204)]
    public async Task<IActionResult>DeleteComment(Guid postId, Guid id)
    {
        await _serviceManager.CommentService.DeleteComment(postId, id);

        return NoContent();
    }
}