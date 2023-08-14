using System.Diagnostics.CodeAnalysis;
using System.Threading.RateLimiting;
using Microsoft.AspNetCore.RateLimiting;

namespace Medium.RateLimit.Fixed;

[ExcludeFromCodeCoverage]
public static class RateLimitConfig
{
    public static IServiceCollection AddFixedWindowRules(this IServiceCollection services) =>
        services.AddRateLimiter(_ =>
        {
            _.AddFixedWindowLimiter(policyName: "fixed", options =>
            {
                options.PermitLimit = 4;
                options.Window = TimeSpan.FromSeconds(20);
                options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                options.QueueLimit = 0;
            }).OnRejected = async (context, token) =>
            {
                context.HttpContext.Response.StatusCode = 429;
                await context.HttpContext.Response.WriteAsync("Too many requests. ", cancellationToken: token);
            };
        });
}