using SampleBackend.Models;
using System.Text.Json;

namespace SampleBackend.Services;

public static class UserService
{
    static List<User> Users { get; }
    static int nextId = 2;
    static UserService()
    {
        var awaiter = CallUsers();
        var result = awaiter.Result;
        List<User>? convert = JsonSerializer.Deserialize<List<User>>(result);
        if (convert is not null)
        {
            Users = convert;
            nextId = convert.Count;
        }
        else
        {
            Users = new List<User>{ 
            new User {
                id = 1,
                name = "Leanne Graham",
                username = "Bret",
                email = "Sincere@april.biz",
                address = new Address {
                    street = "Kulas Light",
                    suite = "Apt. 556",
                    city = "Gwenborough",
                    zipcode = "92998-3874",
                    geo = new Geo {
                        lat = "-37.3159",
                        lng = "81.1496"
                    }
                },
                phone = "1-770-736-8031 x56442",
                website = "hildegard.org",
                company = new Company {
                    name = "Romaguera-Crona",
                    catchPhrase = "Multi-layered client-server neural-net",
                    bs = "harness real-time e-markets"
                }
            }
            };
        }
    }

    private static async Task<string> CallUsers()
    {
        using var client = new HttpClient();
        var response = client.GetStringAsync("https://jsonplaceholder.typicode.com/users");
        return await response;
    }
    
    public static List<User> GetAll() => Users;

    public static User? Get(int id) => Users.FirstOrDefault(p => p.id == id);

    public static void Add(User user)
    {
        user.id = nextId++;
        Users.Add(user);
    }

    public static void Delete(int id)
    {
        var user = Get(id);
        if(user is null)
            return;

        Users.Remove(user);
    }

    public static void Update(User user)
    {
        var index = Users.FindIndex(p => p.id == user.id);
        if(index == -1)
            return;

        Users[index] = user;
    }
}