using SaaS.MultiTenant.Api.Models;

namespace SaaS.MultiTenant.Api.Tenancy;

public sealed class TenantContext
{
    public Tenant? CurrentTenant { get; set; }
}
