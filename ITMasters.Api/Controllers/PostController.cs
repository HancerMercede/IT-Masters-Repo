using Microsoft.Extensions.FileProviders;

namespace ITMasters.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PostController : ControllerBase
{
    private readonly IServiceManager _serviceManager;
    private readonly ILogger<PostController> _logger;
    
    public PostController(IServiceManager serviceManager, ILogger<PostController> logger)
    {
        _serviceManager = serviceManager;
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<IEnumerable<PostDto>>> GetAll()
    {
        var posts = await _serviceManager.PostService.GetAllPost();

        if (!posts.Any())
        {
            _logger.LogInformation("There is nothing in the db please create some new.");
            return NotFound($"There is nothing in the db please create some new.");
        }
        
        var postsDtos = posts.Adapt<IEnumerable<PostDto>>();
        
        return Ok(postsDtos);
    }
    
    [HttpGet("{id:guid}", Name = "GetPostById")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<IEnumerable<PostDto>>> GetById(Guid id)
    {
        var postdb = await _serviceManager.PostService.GetPostById(id);

        if (postdb is null)
        {
            _logger.LogInformation($"There is nothing in the db with this Id: {id}, please verify.");
            return NotFound($"There is nothing in the db with this Id: {id}, please verify.");
        }

        var postDto = postdb.Adapt<PostDto>();
        
        return Ok(postDto);
    }

    [HttpPost("CreatePost")]
    [ProducesResponseType(201)]
    [ProducesResponseType(422)]
    public async Task<ActionResult<PostDto>> CreatePost([FromForm]PostCreateDto model)
    {
        if (!ModelState.IsValid)
            return StatusCode(422);
        
        var postdb = model.Adapt<Post>();
        var result = await _serviceManager.PostService.CreatePost(postdb);

        var postDto = result.Adapt<PostDto>();

        return new CreatedAtRouteResult("GetPostById", new { Id = postDto.Id }, postDto);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<PostDto>> UpdatePost(Guid id, [FromBody] PostUpdateDto modelToUpdate)
    {

        var existPost = await _serviceManager.PostService.GetPostById(id);

        if (existPost is null)
        {
            _logger.LogInformation($"There is not any post with this Id: {id} in the db, please verify.");
            return NotFound($"There is not any post with this Id: {id} in the db, please verify.");
        }
        
        existPost.Title = modelToUpdate.Title;
        existPost.Content = modelToUpdate.Content;
        existPost.Image = modelToUpdate.Image;
        
        
        if (!ModelState.IsValid)
            return StatusCode(422);
        
        var postdb = modelToUpdate.Adapt(existPost);
        var result = await _serviceManager.PostService.UpdatePost(id, postdb);

        var postDto = result.Adapt<PostDto>();

        return Ok(postDto);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Delete(Guid id)
    {
        _logger.LogInformation($"Deleting the Post with id: {id}");
        await _serviceManager.PostService.DeletePost(id);

        return NoContent();
    }
}