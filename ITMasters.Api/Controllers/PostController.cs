namespace ITMasters.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
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
            return NotFound($"There is nothing in the db please create some new.");
        
        var postsDtos = posts.Adapt<IEnumerable<PostDto>>();
        
        return Ok(postsDtos);
    }
    
    [HttpGet("{Id:guid}", Name = "GetPostById")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<IEnumerable<PostDto>>> GetById(Guid Id)
    {
        var postdb = await _serviceManager.PostService.GetPostById(Id);
        
        if (postdb is null)
            return NotFound($"There is nothing in the db please create some new.");
        
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

    [HttpPut("{Id:guid}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<PostDto>> UpdatePost(Guid Id, [FromBody] PostUpdateDto modelToUpdate)
    {

        var existPost = await _serviceManager.PostService.GetPostById(Id);

        if (existPost is null)
            return NotFound("There is not any post with this Id {Id} in the db.");

        existPost.Title = modelToUpdate.Title;
        existPost.Content = modelToUpdate.Content;
        existPost.Image = modelToUpdate.Image;
        
        
        if (!ModelState.IsValid)
            return StatusCode(422);
        
        var postdb = modelToUpdate.Adapt(existPost);
        var result = await _serviceManager.PostService.UpdatePost(Id, postdb);

        var postDto = result.Adapt<PostDto>();

        return Ok(postDto);
    }
}