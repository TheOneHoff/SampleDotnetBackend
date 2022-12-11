using SampleBackend.Models;
using SampleBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace SampleBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<User>> GetAll() =>
        UserService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<User> Get(int id)
    {
        var user = UserService.Get(id);

        if(user is null)
            return NotFound();

        return user;
    }
}