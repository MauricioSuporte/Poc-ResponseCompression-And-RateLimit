var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddResponseCompression();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.UseResponseCompression();

app.Run();
