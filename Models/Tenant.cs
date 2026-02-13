namespace SaaS.MultiTenant.Api.Models;

public sealed class Tenant
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required string ConnectionString { get; init; }
}
