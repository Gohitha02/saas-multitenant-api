using Microsoft.EntityFrameworkCore;
using SaaS.MultiTenant.Api.Models;
using SaaS.MultiTenant.Api.Tenancy;

namespace SaaS.MultiTenant.Api.Data;

public sealed class AppDbContext : DbContext
{
    private readonly TenantContext _tenantContext;

    public AppDbContext(DbContextOptions<AppDbContext> options, TenantContext tenantContext)
        : base(options)
    {
        _tenantContext = tenantContext;
    }

    public DbSet<ProjectItem> Projects => Set<ProjectItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProjectItem>(b =>
        {
            b.ToTable("Projects");
            b.HasKey(x => x.Id);
            b.Property(x => x.Name).HasMaxLength(200).IsRequired();
        });
    }
}

