using System.Threading.RateLimiting;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddResponseCompression(options =>
{
    // Configure os algoritmos de compressão desejados
    options.Providers.Add<GzipCompressionProvider>();

    // Opções adicionais de compressão
    options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/json" });
    options.EnableForHttps = true;
});

builder.Services.AddRateLimiter(options =>
{
    // Adiciona status code 429 quando limite atingido
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

    // Adiciona política de janela fixa
    options.AddFixedWindowLimiter(policyName: "FixedWindowRateLimiter", options =>
    {
        options.PermitLimit = 5;
        options.Window = TimeSpan.FromMinutes(1);
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.QueueLimit = 0;
    });

    // Adiciona mensagem de limite atingido ao usuario
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
