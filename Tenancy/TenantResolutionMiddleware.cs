using SaaS.MultiTenant.Api.Models;

namespace SaaS.MultiTenant.Api.Tenancy;

public sealed class TenantResolutionMiddleware : IMiddleware
{
    private readonly TenantContext _tenantContext;
    private readonly IReadOnlyDictionary<string, Tenant> _tenants;

    public TenantResolutionMiddleware(TenantContext tenantContext, IConfiguration config)
    {
        _tenantContext = tenantContext;

        var tenants = config.GetSection("Tenants").Get<List<Tenant>>() ?? new();
        _tenants = tenants.ToDictionary(t => t.Id, StringComparer.OrdinalIgnoreCase);
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (!context.Request.Headers.TryGetValue("X-Tenant", out var tenantIdValues))
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsync("Missing required header: X-Tenant");
            return;
        }

        var tenantId = tenantIdValues.ToString().Trim();
        if (string.IsNullOrWhiteSpace(tenantId) || !_tenants.TryGetValue(tenantId, out var tenant))
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsync("Invalid tenant. Provide a valid X-Tenant.");
            return;
        }

        _tenantContext.CurrentTenant = tenant;
        await next(context);
    }
}
