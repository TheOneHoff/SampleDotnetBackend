using SampleBackend.Authorization;
using SampleBackend.Models;
using SampleBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace SampleBackend.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AlbumsController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Album>> GetAll() =>
        AlbumService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Album> Get(int id)
    {
        var album = AlbumService.Get(id);

        if(album is null)
            return NotFound();

        return album;
    }
}