using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddResponseCompression();
builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
    
    options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
    RateLimitPartition.GetFixedWindowLimiter(
    partitionKey: httpContext.User.Identity?.Name ??
                  httpContext.Request.Headers.Host.ToString(),
        factory: partition => new FixedWindowRateLimiterOptions
        {
            AutoReplenishment = true,
            PermitLimit = 10,
            QueueLimit = 0,
            Window = TimeSpan.FromMinutes(1)
        }));

    options.OnRejected = async (context, token) =>
    {
        context.HttpContext.Response.StatusCode = 429;
        if (context.Lease.TryGetMetadata(MetadataName.RetryAfter, out var retryAfter))
        {
            await context.HttpContext.Response.WriteAsync(
                $"Muitos requests feitos. Tente novamente depois " +
                $"de {retryAfter.TotalMinutes} minuto(s). \n\n" +
                $"Leia mais sobre nossa politica de limites em " +
                $"https://exemplo.org/docs/ratelimiting.",
                cancellationToken: token);
        }
        else
        {
            await context.HttpContext.Response.WriteAsync(
                "Muitos requests feitos. Tente novamente mais tarde. " +
                "Leia mais sobre o assunto em https://exemplo.org/docs/ratelimiting.",
                cancellationToken: token);
        }
    };
});

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.UseResponseCompression();

app.UseRateLimiter();

app.Run();
