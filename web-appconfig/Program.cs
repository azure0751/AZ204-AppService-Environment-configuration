using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Enable Razor Pages
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();
app.MapRazorPages();

// Default endpoint – if user goes to "/"
app.MapGet("/", (HttpContext context) =>
{
    // Read environment variable
    var message = Environment.GetEnvironmentVariable("MY_APP_MESSAGE")
                  ?? "No message found in environment variable :  Setup 'MY_APP_MESSAGE' in application configuration";

    // Return simple HTML
    return Results.Content($"""
        <html>
          <head><title>Environment Message</title></head>
          <body>
            <h1>Message from Environment Configuration : </h1>
            <p>{message}</p>
          </body>
        </html>
        """, "text/html");
});

app.Run();
