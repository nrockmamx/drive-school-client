using DriveSchoolServer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text.Json;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
builder.Services.AddHealthChecks();
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));


builder.Services.AddHostedService<ServiceStart>();

var app = builder.Build();

app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});


app.UseHttpsRedirection();

app.MapControllers();

app.MapHealthChecks("/health", new HealthCheckOptions { ResponseWriter = WriteResponse });

app.RunAsync("http://0.0.0.0:21998");


var builder1 = WebApplication.CreateBuilder(args);

// Add services to the container.

builder1.Services.AddControllers();
builder1.Services.AddHealthChecks();


var app1 = builder1.Build();

app1.UseHttpsRedirection();

app1.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});


app1.MapControllers();

app1.MapHealthChecks("/health", new HealthCheckOptions { ResponseWriter = WriteResponse });

await app1.RunAsync("http://0.0.0.0:22001");



static Task WriteResponse(HttpContext context, HealthReport result)
{
    context.Response.ContentType = "application/json; charset=utf-8";

    var options = new JsonWriterOptions
    {
        Indented = true
    };

    using var stream = new MemoryStream();
    using (var writer = new Utf8JsonWriter(stream, options))
    {
        writer.WriteStartObject();
        writer.WriteString("status", "success");
        writer.WriteString("message", "OK");
        writer.WriteNull("data");
        writer.WriteEndObject();
    }

    var json = Encoding.UTF8.GetString(stream.ToArray());

    return context.Response.WriteAsync(json);
}