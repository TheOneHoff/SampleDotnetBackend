using Microsoft.Extensions.Options;
using System.Text;
using SampleBackend.Services;

namespace SampleBackend.Authorization;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AppSettings _appSettings;

    public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
    {
        _next = next;
        _appSettings = appSettings.Value;
    }

    public async Task Invoke(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"];

        if (token == "Bearer af24353tdsfw")
        {
            context.Items["User"] = UserService.Get(1);
        }
        
        await _next(context);
    }
}