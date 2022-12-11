using SampleBackend.Models;
using System.Text.Json;

namespace SampleBackend.Services;

public static class PostService
{
    static List<Post> Posts { get; }
    static int nextId = 101;
    static PostService()
    {
        var awaiter = CallPosts();
        var result = awaiter.Result;
        List<Post>? convert = JsonSerializer.Deserialize<List<Post>>(result);
        if (convert != null)
        {
            Posts = convert;
        }
        else
        {
            Posts = new List<Post>{ 
                new Post {
                    userId = 1,
                    id = 1,
                    title = "quidem molestiae enim"
                }
            };
        }
    }

    public static async Task<string> CallPosts()
    {
        using var client = new HttpClient();
        var response = client.GetStringAsync("https://jsonplaceholder.typicode.com/posts");
        return await response;
    }

    public static List<Post> GetAll() => Posts;

    public static Post? Get(int id) => Posts.FirstOrDefault(p => p.id == id);

    public static void Add(Post post)
    {
        post.id = nextId++;
        Posts.Add(post);
    }

    public static void Delete(int id)
    {
        var post = Get(id);
        if(post is null)
            return;

        Posts.Remove(post);
    }

    public static void Update(Post post)
    {
        var index = Posts.FindIndex(p => p.id == post.id);
        if(index == -1)
            return;

        Posts[index] = post;
    }
}