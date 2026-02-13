namespace SaaS.MultiTenant.Api.Models;

public sealed class ProjectItem
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
}
