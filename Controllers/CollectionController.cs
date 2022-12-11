using SampleBackend.Models;
using SampleBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace SampleBackend.Controllers;

// Class for returning the aggregate
public class Resources
{
    public List<Post>? Posts { get; set;}
    public List<Album>? Albums { get; set;}
    public List<User>? Users { get; set;}
}

[ApiController]
[Route("api/[controller]")]
public class CollectionController : ControllerBase
{
    [HttpGet]
    public ActionResult<Resources> Aggregate()
    {
        // Randomise the number of items for each resource
        Random rnd = new Random();
        int u = rnd.Next(0,10);
        int p = rnd.Next(0,30-u);
        int a = 30 - u - p;

        // Get the total number of each resource
        int postCount = PostService.GetAll().Count;
        int albumCount = AlbumService.GetAll().Count;
        int userCount = UserService.GetAll().Count;

        // Randomly select items from each resource and add it to the resources class
        Resources result = new Resources {};

        //Posts
        List<Post> posts = new List<Post> {};
        for (int i = 0; i < p; i++)
        {
            int itemId = rnd.Next(1,postCount);
            Post? item = PostService.Get(itemId);
            if (item is null)
                return NotFound();
            posts.Add(item);
        }
        result.Posts = posts;

        //Albums
        List<Album> albums = new List<Album> {};
        for (int i = 0; i < a; i++)
        {
            int itemId = rnd.Next(1,albumCount);
            Album? item = AlbumService.Get(itemId);
            if (item is null)
                return NotFound();
            albums.Add(item);
        }
        result.Albums = albums;

        //Users
        List<User> users = new List<User> {};
        for (int i = 0; i < u; i++)
        {
            int itemId = rnd.Next(1,userCount);
            User? item = UserService.Get(itemId);
            if (item is null)
                return NotFound();
            users.Add(item);
        }
        result.Users = users;

        return result;
    }

}