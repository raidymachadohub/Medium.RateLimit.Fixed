using Medium.RateLimit.Fixed;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Host.ConfigureServices((_, services) =>
{
    services
        .AddFixedWindowRules();
});

var app = builder.Build();

app.MapControllers();
app.UseRateLimiter();

app.Run();