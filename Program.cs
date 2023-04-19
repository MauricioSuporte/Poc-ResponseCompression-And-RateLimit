using System.Threading.RateLimiting;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddResponseCompression(options =>
{
    // Configure the wishing algorithms
    options.Providers.Add<GzipCompressionProvider>();

    // Additional compression options
    options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/json" });
    options.EnableForHttps = true;
});

builder.Services.AddRateLimiter(options =>
{
    // Add status code 429 when limit reached
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

    // Add fixed window policy
    options.AddFixedWindowLimiter(policyName: "FixedWindowRateLimiter", options =>
    {
        options.PermitLimit = 5;
        options.Window = TimeSpan.FromMinutes(1);
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.QueueLimit = 0;
    });

    // Add limit reached message to user
    options.OnRejected = async (context, token) =>
    {
        context.HttpContext.Response.StatusCode = 429;
        if (context.Lease.TryGetMetadata(MetadataName.RetryAfter, out var retryAfter))
        {
            await context.HttpContext.Response.WriteAsync(
                $"Lots of requests. Try again later " +
                $"{retryAfter.TotalMinutes} minutes(s). \n\n" +
                $"Read more about our limits policy at " +
                $"https://exemple.org/docs/ratelimiting.",
                cancellationToken: token);
        }
        else
        {
            await context.HttpContext.Response.WriteAsync(
                "Many requests. Try again later " +
                "Read more about our limits policy at " +
                "https://exemple.org/docs/ratelimiting.",
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
