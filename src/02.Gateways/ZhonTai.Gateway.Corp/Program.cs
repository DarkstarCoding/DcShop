using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyPolicy", policy =>
    {
        policy
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors("AllowAnyPolicy");

app.MapReverseProxy();

app.MapGet("/", () => $"The {Assembly.GetEntryAssembly()?.GetName().Name} has started.");

/*
app.MapGet("/", async (HttpResponse response) =>
{
    var serviceList = new List<Tuple<string, string>>
    {
        new Tuple<string, string>("AdminȨ�޽ӿ��ĵ�","/doc/admin/index.html"),
    };

    var html = $"<html><body>";

    serviceList.ForEach(m =>
    {
        html += $"""<a href='{m.Item2}' target="_blank">{m.Item1}</a></br>""";
    });

    html += "</body></html>";

    response.ContentType = "text/html;charset=UTF-8";

    await response.WriteAsync(html);
});
*/

app.Run();