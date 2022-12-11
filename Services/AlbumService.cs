using SampleBackend.Models;
using System.Text.Json;

namespace SampleBackend.Services;

public static class AlbumService
{
    static List<Album> Albums { get; }
    static int nextId = 101;
    static AlbumService()
    {
        var awaiter = CallAlbums();
        var result = awaiter.Result;
        List<Album>? convert = JsonSerializer.Deserialize<List<Album>>(result);
        if (convert != null)
        {
            Albums = convert;
        }
        else
        {
            Albums = new List<Album>{ 
                new Album {
                    userId = 1,
                    id = 1,
                    title = "quidem molestiae enim"
                }
            };
        }
    }

    public static async Task<string> CallAlbums()
    {
        using var client = new HttpClient();
        var response = client.GetStringAsync("https://jsonplaceholder.typicode.com/albums");
        return await response;
    }

    public static List<Album> GetAll() => Albums;

    public static Album? Get(int id) => Albums.FirstOrDefault(p => p.id == id);

    public static void Add(Album album)
    {
        album.id = nextId++;
        Albums.Add(album);
    }

    public static void Delete(int id)
    {
        var album = Get(id);
        if(album is null)
            return;

        Albums.Remove(album);
    }

    public static void Update(Album album)
    {
        var index = Albums.FindIndex(p => p.id == album.id);
        if(index == -1)
            return;

        Albums[index] = album;
    }
}