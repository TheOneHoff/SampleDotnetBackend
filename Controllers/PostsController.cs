using SampleBackend.Models;
using SampleBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace SampleBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Post>> GetAll() =>
        PostService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Post> Get(int id)
    {
        var post = PostService.Get(id);

        if(post is null)
            return NotFound();

        return post;
    }

    [HttpPost]
    public IActionResult Create(Post post)
    {
        PostService.Add(post);
        return CreatedAtAction(nameof(Create), new {id = post.id}, post);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Post post)
    {
        if (id != post.id)
            return BadRequest();

        var currentPost = PostService.Get(id);
        if (currentPost is null)
            return NotFound();

        PostService.Update(post);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var post = PostService.Get(id);

        if (post is null)
            return NotFound();

        PostService.Delete(id);

        return NoContent();
    }
}