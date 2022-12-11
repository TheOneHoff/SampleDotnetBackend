using SampleBackend.Models;
using System.Text.Json;

namespace SampleBackend.Services;

public static class PostService
{
    static List<Post> Posts { get; }
    static int nextId = 2;
    static PostService()
    {
        var awaiter = CallPosts();
        var result = awaiter.Result;
        List<Post>? convert = JsonSerializer.Deserialize<List<Post>>(result);
        if (convert is not null)
        {
            Posts = convert;
            nextId = convert.Count;
        }
        else
        {
            Posts = new List<Post>{ 
                new Post {
                    userId = 1,
                    id = 1,
                    title = "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
                    body = "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto"
                }
            };
        }
    }

    private static async Task<string> CallPosts()
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