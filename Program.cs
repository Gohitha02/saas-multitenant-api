using Microsoft.EntityFrameworkCore;
using SaaS.MultiTenant.Api.Data;
using SaaS.MultiTenant.Api.Tenancy;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Tenant services
builder.Services.AddSingleton<TenantContext>();
builder.Services.AddTransient<TenantResolutionMiddleware>();

// DbContext chooses connection string based on tenant per request
builder.Services.AddDbContext<AppDbContext>((sp, options) =>
{
    var tenantContext = sp.GetRequiredService<TenantContext>();
    var tenant = tenantContext.CurrentTenant;

    var cs = tenant?.ConnectionString
             ?? "Server=(localdb)\\MSSQLLocalDB;Database=SaaS_Default;Trusted_Connection=True;TrustServerCertificate=True";

    options.UseSqlServer(cs);
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// Resolve tenant before controllers
app.UseMiddleware<TenantResolutionMiddleware>();

app.MapControllers();
app.Run();
