using GoBlog.Api.Models;
using GoBlog.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace GoBlog.Api.Controllers;

[Route("post")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly PostService postService;

    public PostController(PostService postService)
    {
        this.postService = postService;
    }

    [HttpGet("{id}")]
    public ActionResult<Post> Get(int id)
    {
        var result = postService.Get(id);
        return Ok(result);
    }

    [HttpGet]
    public ActionResult<List<Post>> GetList()
    {
        var result = postService.GetList();
        return Ok(result);
    }

    [HttpPost]
    public ActionResult<Post> Create([FromBody] Post post)
    {
        var result = postService.Create(post);
        return CreatedAtAction(nameof(Get), new { result.Id }, post);
    }

    [HttpPut("{id}")]
    public ActionResult<Post> Update(int id, [FromBody] Post post)
    {
        post.Id = id;
        var result = postService.Update(post);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        postService.Delete(id);
        return NoContent();
    }
}
